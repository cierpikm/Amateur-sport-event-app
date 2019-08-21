using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;
using ServerCode.Model.Interfaces;

namespace ServerCode.Model.Repositories
{
    public class AdvertisementArchRepository : IAdvertisementRepositoryHistory
    {
        private readonly DatabaseHistoryContext _databaseHistoryContext;

        public AdvertisementArchRepository(DatabaseHistoryContext databaseHistoryContext)
        {
            this._databaseHistoryContext = databaseHistoryContext;
        }


        public async Task<int> Add(Advertisement advertisement)
        {
            await _databaseHistoryContext.AdvertisementsHistory.AddAsync(advertisement);
            await _databaseHistoryContext.SaveChangesAsync();
            return advertisement.Id;
        }
       
        public async Task<List<Advertisement>> GetAllOneAdvertisementsAsync(string userId)
        {
            var advertisements = await _databaseHistoryContext.AdvertisementsHistory
                .Include(c => c.User)
                    .Where(c => c.UserId == userId)
                .Include(c => c.Localization)
                .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
                .ToListAsync();
            return advertisements;
        }
        public async Task<List<Advertisement>> GetAllAcceptedAdvertisementsAsync(string userId)
        {
            var advertisements = await _databaseHistoryContext.UserAdvertisementsHistory
                .Include(c => c.Advertisement)
                .Where(c => c.UserId == userId)
                .Select(c => c.Advertisement)
                .Include(c => c.User)
                .Include(c => c.Localization)
                .Include(c => c.EagerMembers)
                    .ThenInclude(c => c.User)
                .ToListAsync();
            return advertisements;
        }
    }
}
