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
        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        [HttpGet]
        public IActionResult GetAllRegions()
        {
            var region = regionRepository.GetAllRegion();
            return Ok(region);
        }
    }
}
