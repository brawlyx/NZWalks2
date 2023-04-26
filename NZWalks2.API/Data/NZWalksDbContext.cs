using Microsoft.EntityFrameworkCore;
using NZWalks2.API.Models.Domain;

namespace NZWalks2.API.Data
{
    public class NZWalks2DbContext: DbContext
    {
        public NZWalks2DbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }



    }
}
