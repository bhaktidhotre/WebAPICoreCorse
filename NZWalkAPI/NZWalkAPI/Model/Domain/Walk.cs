namespace NZWalkAPI.Model.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lenght { get; set; }
        public Guid RegionId { get; set; }
        public Guid WalkdifficultyId { get; set; }
        public Region Region { get; set; }
        public WalkDifficulty WalkDifficulty { get; set; }
    }
}
