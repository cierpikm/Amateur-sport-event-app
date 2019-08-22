using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;
using ServerCode.Model.Entity;
using ServerCode.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IUserRepository _userRepository;
        private readonly IAdvertisementRepositoryHistory _advertisementRepositoryHistory;
        private readonly IMapper _mapper;
        private readonly IForumRepository _forumRepository;

        public AdvertisementRepository(DatabaseContext databaseContext, IUserRepository userRepository, IAdvertisementRepositoryHistory advertisementRepositoryHistory, IMapper mapper, IForumRepository forumRepository)
        {
            _databaseContext = databaseContext;
            _userRepository = userRepository;
            _advertisementRepositoryHistory = advertisementRepositoryHistory;
            _mapper = mapper;
            _forumRepository = forumRepository;
        }

        public async Task<int> AddAdvertisement(Advertisement advertisement)
        {
            advertisement.Date.AddHours(2);
            await _databaseContext.Advertisements.AddAsync(advertisement);
            await _databaseContext.SaveChangesAsync();
            Forum forum = new Forum()
            {
                AdvertisementId = advertisement.Id    
            };
            await _forumRepository.CreateForum(forum);
            await _forumRepository.AddMemberToForum(advertisement.UserId, forum.Id);
            return advertisement.Id;
        }

        public async Task DeleteAdvertisement(int id)
        {
            var adv = await GetAdvertisement(id);
            _databaseContext.Advertisements.Remove(adv);
            await _databaseContext.SaveChangesAsync();
        }

        public Task<Advertisement> GetAdvertisement(int advertisementID)
        {
            return _databaseContext.Advertisements.FirstAsync(advertisement => advertisement.Id == advertisementID);
        }
        public async Task<List<Advertisement>> GetAll()
        {
            var advertisements = await _databaseContext.Advertisements
            .ToListAsync();
            await AddToArchiveAsync(advertisements);
            return advertisements;
        }

        public async Task<List<Advertisement>> GetAllAdvertisementsAsync(string city, string id)
        {
            List<Advertisement> advertisements;
            if (string.IsNullOrEmpty(city))
            {
                advertisements = await _databaseContext.Advertisements
                .Include(c => c.User)
                .Where(c => c.UserId != id)
                .Include(c => c.Localization)
                .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
                .Where(c => !c.EagerMembers.Any(d => d.UserId == id))
                .ToListAsync();
               // await AddToArchiveAsync(advertisements);
                return advertisements;
            }
                advertisements = await _databaseContext.Advertisements
               .Include(c => c.User)
               .Where(c => c.UserId != id)
               .Include(c => c.Localization)
               .Where(c => c.Localization.City == city)
               .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
               .Where(c => !c.EagerMembers.Any(d => d.UserId == id))
               .ToListAsync();
           // await AddToArchiveAsync(advertisements);
            return advertisements;
        }
        public async Task<List<Advertisement>> GetAllOneAdvertisementsAsync(string userId)
        {
            var advertisements = await _databaseContext.Advertisements
                .Include(c => c.User)
                    .Where(c => c.UserId == userId)
                .Include(c => c.Localization)
                .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
                .ToListAsync();
        //    await AddToArchiveAsync(advertisements);
            return advertisements;
        }
        public async Task<List<Advertisement>> GetAllAcceptedAdvertisementsAsync(string userId)
        {
            var advertisements =  await _databaseContext.UserAdvertisements
                .Include(c => c.Advertisement)
                .Where(c => c.UserId == userId)
                .Select(c => c.Advertisement)
                .Include(c => c.User)
                .Include(c => c.Localization)
                .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
                .ToListAsync();
       //     await AddToArchiveAsync(advertisements);
            return advertisements;
        }

        public async Task<int> UpdateAdvertisement(Advertisement advertisement)
        {
            _databaseContext.Advertisements.Update(advertisement);
            await _databaseContext.SaveChangesAsync();
            return advertisement.Id;

        }
        public async Task AddMemberToAdvertisement(string userId, int advertisementId)
        {
            var user = await _userRepository.GetUser(userId);
            var advertisement = await GetAdvertisement(advertisementId);
            UserAdvertisement userAdvertisement = new UserAdvertisement()
            {
                AdvertisementId = advertisementId,
                UserId = userId
            };
            await _databaseContext.UserAdvertisements.AddAsync(userAdvertisement);
            await _databaseContext.SaveChangesAsync();
            Forum forum = await _forumRepository.GetForum(advertisementId);
            await _forumRepository.AddMemberToForum(userId, forum.Id);

        }
        public async Task AddToArchiveAsync(List<Advertisement> advertisements)
        {
            DateTime now = DateTime.Now;
            foreach (Advertisement item in advertisements)
            {
                int value = DateTime.Compare(item.Date, now);
                if (value < 0)
                {
                    Advertisement advertisementDTO = _mapper.Map<Advertisement>(item);
                    await _advertisementRepositoryHistory.Add(advertisementDTO);
                    await DeleteAdvertisement(item.Id);
                }
            }
        }
    }
}
