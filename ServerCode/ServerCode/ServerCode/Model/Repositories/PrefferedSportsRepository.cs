using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;

namespace ServerCode.Model.Repositories
{
    public class PrefferedSportsRepository : BaseRepository<SportName>
    {
        public PrefferedSportsRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<SportName> Get(int id)
        {
            return await _databaseContext.SportNames.FirstAsync(c => c.Id == id);
        }

        public override Task<List<SportName>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<List<SportName>> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override Task<List<SportName>> GetAllOneUser(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<int> UpdateAdvertisement(SportName t)
        {
            throw new NotImplementedException();
        }
    }
}
