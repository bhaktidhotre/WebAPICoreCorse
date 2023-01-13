using NZWalkAPI.Model.Domain;

namespace NZWalkAPI.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegion();
        Task<Region> GetRegion(Guid Id);
        Task<Region> AddRegion(Region region);
        Task<Region> DeleteRegion(Guid Id); 
        Task<Region> UpdateRegion(Guid Id , Region region); 
    }
}
