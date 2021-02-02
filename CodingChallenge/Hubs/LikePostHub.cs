using CodingChallenge.MessageQueue;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Tossit.WorkQueue.Job;

namespace CodingChallenge.Hubs
{
    public class LikePostHub : Hub
    {
        private IJobDispatcher _jobDispatcher;

        public LikePostHub(IJobDispatcher jobDispatcher)
        {
            _jobDispatcher = jobDispatcher;
        }

        public async Task SendPostLike(string postId)
        {
            _jobDispatcher.Dispatch(new LikePostJob
            {
                Data = postId
            });            
        }
    }
}
