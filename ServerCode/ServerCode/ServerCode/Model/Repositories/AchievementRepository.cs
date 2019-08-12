using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;

namespace ServerCode.Model.Repositories
{
    public class AchievementRepository : BaseRepository<Achievement>
    {
        public AchievementRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<Achievement> Get(int id)
        {
            return await _databaseContext.Achievements.FirstAsync(c => c.Id == id);
        }

        public override async Task<List<Achievement>> GetAll()
        {
            return await _databaseContext.Achievements.ToListAsync();
        }

        public override async Task<int> UpdateAdvertisement(Achievement achievement)
        {
            _databaseContext.Achievements.Update(achievement);
            await _databaseContext.SaveChangesAsync();
            return achievement.Id;
        }
        public override async Task<List<Achievement>> GetAllOneUser(string id)
        {
            return await _databaseContext.Achievements.Where(c => c.UserId == id).ToListAsync();
        }

        public override Task<List<Achievement>> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
