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
    }
}
