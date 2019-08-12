using ServerCode.Model.Database;
using ServerCode.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DatabaseContext _databaseContext;

        public BaseRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<T> Add(T t)
        {
            await _databaseContext.Set<T>().AddAsync(t);
            await _databaseContext.SaveChangesAsync();
            return t;
        }

        public async Task Delete(int id)
        {
            var adv = await Get(id);
            _databaseContext.Set<T>().Remove(adv);
            await _databaseContext.SaveChangesAsync();
        }
        public abstract Task<List<T>> GetAllOneUser(string id);
        public abstract Task<T> Get(int id);
        public abstract Task<List<T>> GetAll();
        public abstract Task<int> UpdateAdvertisement(T t);

        public abstract Task<List<T>> GetAll(int pageNumber, int pageSize);
    }
}