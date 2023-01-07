using NZWalkAPI.Model.Domain;

namespace NZWalkAPI.Repository
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllRegion();
    }
}
