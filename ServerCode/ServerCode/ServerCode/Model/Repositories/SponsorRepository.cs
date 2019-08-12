using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;

namespace ServerCode.Model.Repositories
{
    public class SponsorRepository : BaseRepository<Sponsor>
    {
        public SponsorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<Sponsor> Get(int id)
        {
            return await _databaseContext.Sponsors.FirstAsync(c => c.id == id);
        }

        public override Task<List<Sponsor>> GetAll()
        {
            throw new NotImplementedException();
        }

        public override Task<List<Sponsor>> GetAll(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public override Task<List<Sponsor>> GetAllOneUser(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<int> UpdateAdvertisement(Sponsor t)
        {
            throw new NotImplementedException();
        }
    }
}
