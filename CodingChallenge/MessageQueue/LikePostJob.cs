using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tossit.WorkQueue.Job;

namespace CodingChallenge.MessageQueue
{
    public class LikePostJob : IJob<string>
    {
        public string Data { get; set; }

        public string Name => "job.likepost";
    }
}
