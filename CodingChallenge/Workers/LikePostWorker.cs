using CodingChallenge.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tossit.WorkQueue.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using CodingChallenge.Hubs;

namespace CodingChallenge.Workers
{
    public class LikePostWorker : IWorker<string>
    {
        public string JobName => "job.likepost";
        private CodingChallengeContext _codingChallengeContext;
        private readonly ILogger<LikePostWorker> _logger;
        private readonly IHubContext<LikePostHub> _likePostHub;

        public LikePostWorker(
            CodingChallengeContext codingChallengeContext, 
            ILogger<LikePostWorker> logger,
            IHubContext<LikePostHub> likePostHub)
        {
            _codingChallengeContext = codingChallengeContext;
            _logger = logger;
            _likePostHub = likePostHub;
        }

        public bool Work(string postId)
        {
            var result = Task.Run(() =>
            {
                try
                {
                    var updateQuery = 
                    $"UPDATE POST " +
                    $"SET LIKES = (SELECT LIKES " +
                    $"             FROM POST SUBPOST " +
                    $"             WHERE UPPER(SUBPOST.Id) = '{postId.ToUpper()}') + 1 " +
                    $"WHERE UPPER(Id) = '{postId.ToUpper()}'";
                    _codingChallengeContext.Database.ExecuteSqlCommand(updateQuery);
                    //var likes = _codingChallengeContext
                    //    .Database
                    //    .ExecuteSqlInterpolated($"SELECT LIKES FROM POST WHERE UPPER(Id) = '{postId.ToUpper()}");
                    var likes = _codingChallengeContext.Post.AsNoTracking().Single(p => p.Id.Equals(new Guid(postId))).Likes;
                    _likePostHub.Clients.All.SendAsync("UpdateLikes", likes).Wait();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                    return false;
                }
            });

            return result.Result;
        }
    }
}
