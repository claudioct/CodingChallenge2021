using CodingChallenge.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodingChallenge.Data
{
    public class CodingChallengeContext : DbContext
    {
        public CodingChallengeContext(DbContextOptions<CodingChallengeContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Post { get; set; }
    }
}
