using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalkAPI.Model.Domain;
using NZWalkAPI.Repository;

namespace NZWalkAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;    
        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var region = await regionRepository.GetAllRegion();

            //var regionsDTO = new List<Model.DTO.RegionDTO>();
            //region.ToList().ForEach(region =>
            //{
            //    var regionDTO =  new Model.DTO.RegionDTO()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population,
            //    };
            //    regionsDTO.Add(regionDTO);
            //});
             var regionsDTO =  mapper.Map<List<Model.DTO.RegionDTO>>(region);
             return this.StatusCode(StatusCodes.Status200OK, regionsDTO);
            // return Ok(regionsDTO);
        }
    }
}
