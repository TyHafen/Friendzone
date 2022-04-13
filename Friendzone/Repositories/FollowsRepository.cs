using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Friendzone.Models;

namespace Friendzone.Repositories
{
    public class FollowsRepository
    {
        private readonly IDbConnection _db;

        public FollowsRepository(IDbConnection db)
        {
            _db = db;
        }

        public Follow Create(Follow followData)
        {
            string sql = @"INSERT INTO follows (followerId, followingId)
            VALUES (@FollowingId, @FollowerId);
            SELECT LAST_INSERT_ID();
            ";
            int id = _db.ExecuteScalar<int>(sql, followData);
            followData.Id = id;
            return followData;
        }

        internal List<FollowViewModel> GetProfileFollows(string id)
        {
            string sql = @"SELECT * follows WHERE followingId = @id";
            return _db.Query<FollowViewModel>(sql, new { id }).ToList();
        }
    }
}