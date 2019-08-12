using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetAll();
        Task<List<T>> GetAll(int pageNumber, int pageSize);
        Task<List<T>> GetAllOneUser(string id);
        Task<T> Get(int id);
        Task<T> Add(T t);
        Task Delete(int id);
        Task<int> UpdateAdvertisement(T t);

    }
}
