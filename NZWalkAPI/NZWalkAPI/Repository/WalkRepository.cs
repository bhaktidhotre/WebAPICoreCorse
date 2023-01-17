using Microsoft.EntityFrameworkCore;
using NZWalkAPI.Data;
using NZWalkAPI.Model.Domain;

namespace NZWalkAPI.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalkDbContext nZWalkDbContext;

        public WalkRepository(NZWalkDbContext nZWalkDbContext)
        {
            this.nZWalkDbContext = nZWalkDbContext;
        }

        public async Task<Walk> AddWalk(Walk walk)
        {
            walk.Id = Guid.NewGuid();
            await nZWalkDbContext.AddAsync(walk);
            await nZWalkDbContext.SaveChangesAsync();
            return walk;
        }

       

        public async Task<IEnumerable<Walk>> GetAllWalks()
        {
            return await nZWalkDbContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty).ToListAsync();
        }

        public async Task<Walk> GetWalk(Guid Id )
        {
            return await nZWalkDbContext.Walks.Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Walk> UpdateWalk(Guid Id, Walk walk)
        {
            var exitingWalk = await nZWalkDbContext.Walks.FirstOrDefaultAsync(x => x.Id == Id);
            if (exitingWalk == null)
            {
                return null;
            }
            exitingWalk.Name = walk.Name;
            exitingWalk.Lenght = walk.Lenght;
            exitingWalk.RegionId = walk.RegionId;
            exitingWalk.WalkdifficultyId = walk.WalkdifficultyId;

            await nZWalkDbContext.SaveChangesAsync();
            return exitingWalk;
        }
    }
}
