using ServerCode.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerCode.Model.Interfaces
{
    public interface IForumRepository
    {
        Task<Post> AddPost(Post post);
        Task CreateForum(Forum Forum);
        Task<Forum> GetForum(int advertisementId);
        Task<Forum> GetForumAsync(int advertisementId);
        Task AddMemberToForum(string userId, int forumId);

    }
}
