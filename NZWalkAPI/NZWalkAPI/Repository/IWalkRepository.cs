using NZWalkAPI.Model.Domain;

namespace NZWalkAPI.Repository
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllWalks();
        Task<Walk> GetWalk (Guid Id );
        Task<Walk> AddWalk(Walk walk);
        Task<Walk> UpdateWalk(Guid Id , Walk walk);
    }
}
