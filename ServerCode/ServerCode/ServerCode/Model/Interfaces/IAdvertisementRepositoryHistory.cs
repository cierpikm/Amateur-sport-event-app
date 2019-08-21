using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Interfaces
{
    public interface IAdvertisementRepositoryHistory
    {
        Task<int> Add(Advertisement advertisement);
        Task<List<Advertisement>> GetAllOneAdvertisementsAsync(string userId);
        Task<List<Advertisement>> GetAllAcceptedAdvertisementsAsync(string userId);
    }
}
