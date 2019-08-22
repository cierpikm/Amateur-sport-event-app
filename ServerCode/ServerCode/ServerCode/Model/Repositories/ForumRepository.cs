using Microsoft.EntityFrameworkCore;
using ServerCode.Model.Database;
using ServerCode.Model.Entity;
using ServerCode.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Repositories
{
    public class ForumRepository : IForumRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ForumRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddMemberToForum(string userId, int forumId)
        {

            UserForum userForum = new UserForum()
            {
                ForumId = forumId,
                UserId = userId
            };
           await _databaseContext.UserForums.AddAsync(userForum);
           await _databaseContext.SaveChangesAsync();
        }

        public async Task<Post> AddPost(Post post)
        {
            await _databaseContext.Posts.AddAsync(post);
            await _databaseContext.SaveChangesAsync();
            return post;
        }

        public async Task CreateForum(Forum Forum)
        {
            await _databaseContext.Forums.AddAsync(Forum);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<Forum> GetForumAsync(int advertisementId)
        {
            return await _databaseContext.Forums
                .Where(c => c.AdvertisementId == advertisementId)
                .FirstOrDefaultAsync();
        }
        public async Task<Forum> GetForum(int advertisementId)
        {
            return await _databaseContext.Forums
                .Where(c => c.AdvertisementId == advertisementId)
                .Include(c => c.Posts)
                    .ThenInclude(c => c.Owner)
                .Include(c => c.Users)
                    .ThenInclude(c=> c.User)
                .FirstOrDefaultAsync();
        }

    }
}
