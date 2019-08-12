using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;

namespace ServerCode.Model.Repositories
{
    public class EventRepository : BaseRepository<Event>
    {
        public EventRepository(DatabaseContext databaseContext) : base(databaseContext)
        {
        }

        public override async Task<Event> Get(int id)
        {
            return await _databaseContext.Events.FirstAsync(c => c.Id == id);

        }

        public override async Task<List<Event>> GetAll()
        {
            return await _databaseContext.Events
                .Include(c => c.Sponsors)
                .Include(c => c.Localization)
                .ToListAsync();
        }

        public override async Task<List<Event>> GetAll(int pageNumber, int pageSize)
        {

            return await _databaseContext.Events
                .Include(c => c.Sponsors)
                .Include(c => c.Localization)
                .Skip((pageNumber - 1)*pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public override Task<List<Event>> GetAllOneUser(string id)
        {
            throw new NotImplementedException();
        }

        public override Task<int> UpdateAdvertisement(Event t)
        {
            throw new NotImplementedException();
        }
    }
}
