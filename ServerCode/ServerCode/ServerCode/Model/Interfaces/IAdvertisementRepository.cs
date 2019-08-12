using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Interfaces
{
    public interface IAdvertisementRepository
    {
        Task<List<Advertisement>> GetAllAdvertisementsAsync(string city, string id);
        Task<List<Advertisement>> GetAllOneAdvertisementsAsync(string userId);
        Task<List<Advertisement>> GetAll();
        Task<List<Advertisement>> GetAllAcceptedAdvertisementsAsync(string userId);
        Task<Advertisement> GetAdvertisement(int advertisementID);
        Task<int> AddAdvertisement(Advertisement advertisement);
        Task DeleteAdvertisement(int advertisementID);
        Task<int> UpdateAdvertisement(Advertisement advertisement);
        Task AddMemberToAdvertisement(string userId, int advertisementId);
    }
}
