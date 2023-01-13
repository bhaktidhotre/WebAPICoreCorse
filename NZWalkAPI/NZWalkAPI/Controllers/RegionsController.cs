using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalkAPI.Model;
using NZWalkAPI.Model.Domain;
using NZWalkAPI.Repository;
using System.Net;

namespace NZWalkAPI.Controllers
{
    
    [ApiController]
    [Route("[Controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        RequestResponse res = new RequestResponse();
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


        [HttpGet]
        [Route("GetRegion{Id:Guid}")]
        [ActionName("GetRegion{Id:Guid}")]
        public async Task<IActionResult> GetRegion(Guid Id)
        {
            var region = await regionRepository.GetRegion(Id);
            if (region == null)
            {
                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true;
                res.Message = "Successfully";
                res.Data = null;
                return this.StatusCode(StatusCodes.Status404NotFound, res);
            }
            else
            {
                var regionDTO = mapper.Map<Model.DTO.RegionDTO>(region);
                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true;
                res.Message = "Successfully";
                res.Data = regionDTO;
                return this.StatusCode(StatusCodes.Status200OK, res);
                //return new JsonResult(Ok(regionDTO));
            }

        }

        [HttpPost]
        [Route("AddRegion")]
        public async Task<IActionResult> AddRegion(Model.DTO.AddRegionDTO addRegion)
        {
            //Request (DTO) to Domain Model
            var region = new Region()
            {
                Code = addRegion.Code,
                Area = addRegion.Area,
                Lat = addRegion.Lat,
                Long = addRegion.Long,
                Name = addRegion.Name,
                Population = addRegion.Population
            };
            //Pass details to Repository
            region = await regionRepository.AddRegion(region);
            //Convert back to DTO
            var regionDTO = new Model.DTO.RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };
            if(regionDTO == null)
            {
                res.Code = Convert.ToInt32(HttpStatusCode.BadRequest);
                res.Status = true;
                res.Message = "Somthing Went to wrong";
                res.Data = regionDTO;
                return this.StatusCode(StatusCodes.Status400BadRequest, res);
            }
            else
            {
                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true;
                res.Message = "Record Inserted Successfully";
                res.Data = regionDTO;
                return this.StatusCode(StatusCodes.Status200OK, res);
            }
          //  return new JsonResult(Ok(regionDTO));
            // return CreatedAtAction(nameof(GetRegion), new {id =regionDTO.Id },  );
        }

        [HttpDelete]
        [Route("DeleteRegion{Id:Guid}")]
        public async Task<IActionResult> DeleteRegion(Guid Id)
        {
           //Get region from database
           var region = await regionRepository.DeleteRegion(Id);

            //If null notfound
           
            if (region == null)
            {
                res.Code = Convert.ToInt32(HttpStatusCode.NotFound);
                res.Status = true;
                res.Message = "Somthing Went to wrong";
                res.Data = null;
                return this.StatusCode(StatusCodes.Status404NotFound, res);
            }
            else
            {
                //Convert back to DTO
                var regionDTO = new Model.DTO.RegionDTO
                {
                    Id = region.Id,
                    Code = region.Code,
                    Area = region.Area,
                    Lat = region.Lat,
                    Long = region.Long,
                    Name = region.Name,
                    Population = region.Population
                };

                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true;
                res.Message = "Record Deleted Successfully";
                res.Data = regionDTO;
                return this.StatusCode(StatusCodes.Status200OK, res);
            }
            
            //  return new JsonResult(Ok(regionDTO));
            // return CreatedAtAction(nameof(GetRegion), new {id =regionDTO.Id },  );
        }

        [HttpPut]
        [Route("UpdateRegion{Id:Guid}")]
        public async Task<IActionResult> UpdateRegion([FromRoute] Guid Id,[FromBody] Model.DTO.UpdateRegionDTO updateRegion)
        {
            //Request (DTO) to Domain Model
            var region = new Region()
            {
                Code = updateRegion.Code,
                Area = updateRegion.Area,
                Lat = updateRegion.Lat,
                Long = updateRegion.Long,
                Name = updateRegion.Name,
                Population = updateRegion.Population
            };
            //Pass details to Repository
            region = await regionRepository.UpdateRegion(Id,region);
            //Convert back to DTO
            
            if (region == null)
            {
                res.Code = Convert.ToInt32(HttpStatusCode.NotFound);
                res.Status = true;
                res.Message = "Record Not Found";
                res.Data = null;
                return this.StatusCode(StatusCodes.Status404NotFound, res);
            }
            else
            {
                var regionDTO = new Model.DTO.RegionDTO
                {
                    Id = region.Id,
                    Code = region.Code,
                    Area = region.Area,
                    Lat = region.Lat,
                    Long = region.Long,
                    Name = region.Name,
                    Population = region.Population
                };
                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true; 
                res.Message = "Record Updated Successfully";
                res.Data = regionDTO;
                return this.StatusCode(StatusCodes.Status200OK, res);
            }
            //  return new JsonResult(Ok(regionDTO));
            // return CreatedAtAction(nameof(GetRegion), new {id =regionDTO.Id },  );
        }

    }
}
