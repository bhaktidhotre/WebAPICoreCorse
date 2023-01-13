using Microsoft.EntityFrameworkCore;
using NZWalkAPI.Data;
using NZWalkAPI.Model.Domain;

namespace NZWalkAPI.Repository
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NZWalkDbContext nZWalkDbContext;   

        public RegionRepository(NZWalkDbContext nZWalkDbContext)
        {
            this.nZWalkDbContext = nZWalkDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllRegion()
        {
            return await nZWalkDbContext.Regions.ToListAsync();
        }
        public async Task<Region> AddRegion(Region region)
        {
            region.Id = Guid.NewGuid();
            await nZWalkDbContext.AddAsync(region);
            await nZWalkDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> GetRegion(Guid Id)
        {
            return await nZWalkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Region> DeleteRegion(Guid Id)
        {
          var region = await nZWalkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if(region == null)
            {
                return null;
            }
            nZWalkDbContext.Regions.Remove(region);
            await  nZWalkDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateRegion(Guid Id, Region region)
        {
            var exitingregion = await nZWalkDbContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (exitingregion == null)
            {
                return null;
            }
            exitingregion.Code = region.Code;
            exitingregion.Name = region.Name;
            exitingregion.Area = region.Area; 
            exitingregion.Lat = region.Lat; 
            exitingregion.Long = region.Long; 
            exitingregion.Population = region.Population;

            await nZWalkDbContext.SaveChangesAsync();
            return exitingregion;
        }
    }
}
