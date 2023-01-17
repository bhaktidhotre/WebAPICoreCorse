using AutoMapper;
namespace NZWalkAPI.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Model.Domain.Region, Model.DTO.RegionDTO>()
                .ReverseMap();

            CreateMap<Model.Domain.Walk, Model.DTO.WalkDTO>()
                .ReverseMap();
            CreateMap<Model.Domain.WalkDifficulty, Model.DTO.WalkDifficultyDTO>()
                .ReverseMap();
        }
    }
}
