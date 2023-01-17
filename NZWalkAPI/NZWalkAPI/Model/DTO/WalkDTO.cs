using NZWalkAPI.Model.Domain;

namespace NZWalkAPI.Model.DTO
{
    public class WalkDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lenght { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkdifficultyId { get; set; }
        public RegionDTO Region { get; set; }   
        public WalkDifficultyDTO WalkDifficulty { get; set; }
    }
    public class AddWalkDTO
    {
        public string Name { get; set; }
        public string Lenght { get; set; }
        public Guid RegionId { get; set; } 
        public Guid WalkdifficultyId { get; set; }
    }
}
