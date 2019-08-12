using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;
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
        private readonly IBaseRepository<AdvertisementArch> _advertisementArchRepository;
        private readonly IMapper _mapper;

        public AdvertisementRepository(DatabaseContext databaseContext, IUserRepository userRepository, IBaseRepository<AdvertisementArch> advertisementArchRepository, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _userRepository = userRepository;
            _advertisementArchRepository = advertisementArchRepository;
            _mapper = mapper;
        }

        public async Task<int> AddAdvertisement(Advertisement advertisement)
        {
            advertisement.Date.AddHours(2);
            await _databaseContext.Advertisements.AddAsync(advertisement);
            await _databaseContext.SaveChangesAsync();
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
            var advertisements =  await _databaseContext.Advertisements
            .ToListAsync();
            await AddToArchiveAsync(advertisements);
            return advertisements;
        }

        public async Task<List<Advertisement>> GetAllAdvertisementsAsync(string city, string id)
        {
            if (string.IsNullOrEmpty(city))
            {
                return await _databaseContext.UserAdvertisements
                .Include(c => c.Advertisement)
                .Where(c => c.Advertisement.UserId != id)
                .Where(c => c.UserId != id)
                .Select(c => c.Advertisement)
                .Include(c => c.User)

                .Include(c => c.Localization)
                .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
                .ToListAsync();
            }
            return await _databaseContext.UserAdvertisements
               .Include(c => c.Advertisement)
               .Where(c => c.Advertisement.UserId != id)
               .Where(c => c.UserId != id)
               .Select(c => c.Advertisement)
               .Include(c => c.User)

               .Include(c => c.Localization)
               .Where(c => c.Localization.City == city)
               .Include(c => c.EagerMembers)
                   .ThenInclude(c => c.User)
               .ToListAsync();
        }
        public async Task<List<Advertisement>> GetAllOneAdvertisementsAsync(string userId)
        {
            return await _databaseContext.Advertisements
                .Include(c => c.User)
                    .Where(c => c.UserId == userId)
                .Include(c => c.Localization)
                .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
                .ToListAsync();
        }
        public async Task<List<Advertisement>> GetAllAcceptedAdvertisementsAsync(string userId)
        {
            return await _databaseContext.UserAdvertisements
                .Include(c => c.Advertisement)
                .Where(c => c.UserId == userId)
                .Select(c => c.Advertisement)
                .Include(c => c.User)
                .Include(c => c.Localization)
                .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
                .ToListAsync();
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

        }
        public async Task AddToArchiveAsync(List<Advertisement> advertisements)
        {
            DateTime now = DateTime.Now;
            foreach (Advertisement item in advertisements)
            {
                int value = DateTime.Compare(item.Date, now);
                if (value < 0)
                {
                    AdvertisementArch advertisementArch = _mapper.Map<AdvertisementArch>(item);
                    await DeleteAdvertisement(item.Id);
                    await _advertisementArchRepository.Add(advertisementArch);
                    
                }
            }
        }
    }
}
