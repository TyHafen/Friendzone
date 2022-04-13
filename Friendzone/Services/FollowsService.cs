using Friendzone.Models;
using Friendzone.Repositories;

namespace Friendzone.Services
{
    public class FollowsService
    {
        private readonly FollowsRepository _fRepo;

        public FollowsService(FollowsRepository fRepo)
        {
            _fRepo = fRepo;
        }

        internal Follow Create(Follow followData)
        {
            return _fRepo.Create(followData);

        }
    }
}