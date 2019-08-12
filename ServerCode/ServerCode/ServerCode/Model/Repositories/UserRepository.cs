using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;
using ServerCode.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _databaseContext;
        private readonly UserManager<User> _userManager;

        public UserRepository(DatabaseContext databaseContext, UserManager<User> userManager)
        {
            _databaseContext = databaseContext;
            _userManager = userManager;
        }

        public async Task<List<User>> GetAll()
        {
            return await _databaseContext.ApplicationUsers.ToListAsync();
        }
        public async Task<User> GetUser1(string userID)
        {
            return await _userManager.FindByIdAsync(userID);
        }
        public async Task<User> GetUser(string userId)
        {
            return await _databaseContext.ApplicationUsers
                .Include(c => c.PrefferedSports)
                .Include(c => c.Achievements)
                .FirstAsync(c => c.Id == userId);
        }

    }
}
