using AutoMapper;
namespace NZWalkAPI.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Model.Domain.Region, Model.DTO.RegionDTO>()
                .ReverseMap();
        }
    }
}
