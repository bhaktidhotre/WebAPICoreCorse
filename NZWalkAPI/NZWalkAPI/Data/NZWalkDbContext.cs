using Microsoft.EntityFrameworkCore;
using NZWalkAPI.Model.Domain;

namespace NZWalkAPI.Data
{
    public class NZWalkDbContext : DbContext
    {
        public NZWalkDbContext(DbContextOptions<NZWalkDbContext> options):base(options) { }
       
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalksDifficulty { get; set; }  
    }
}
