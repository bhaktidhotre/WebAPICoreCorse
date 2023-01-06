using NZWalkAPI.Model.Domain;

namespace NZWalkAPI.Repository
{
    public interface IRegionRepository
    {
        public IEnumerable<Region> GetAllRegion();
    }
}
