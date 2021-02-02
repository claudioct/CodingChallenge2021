using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}
