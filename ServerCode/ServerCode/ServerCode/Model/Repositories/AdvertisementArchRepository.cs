using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;

namespace ServerCode.Model.Repositories
{
    public class AdvertisementArchRepository : BaseRepository<AdvertisementArch>
    {
        public AdvertisementArchRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override Task<AdvertisementArch> Get(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<List<AdvertisementArch>> GetAll()
        {
            return null;
            //return _databaseContext.AdvertisementArches
            //     .Include(c => c.User)
            //     .Include(c => c.Localization)
            //     .Include(c => c.EagerMembers)
            //     .ToListAsync();
        }

        public override Task<List<AdvertisementArch>> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override Task<List<AdvertisementArch>> GetAllOneUser(string id)
        {
            return null;
            //return _databaseContext.AdvertisementArches
            //    .Where(c => c.UserId == id)
            //  .Include(c => c.User)
            //  .Include(c => c.Localization)
            //  .Include(c => c.EagerMembers)
            //  .ToListAsync();
        }

        public override Task<int> UpdateAdvertisement(AdvertisementArch t)
        {
            throw new NotImplementedException();
        }
    }
}
