using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalkAPI.Model;
using NZWalkAPI.Model.Domain;
using NZWalkAPI.Repository;
using System.Net;

namespace NZWalkAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WalkController : ControllerBase
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;
        RequestResponse res = new RequestResponse();
        public WalkController(IWalkRepository walkRepository, IMapper mapper)
        {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalk()
        {
            var walk = await walkRepository.GetAllWalks();
            var walkDTOs = mapper.Map<List<Model.DTO.WalkDTO>>(walk);
            return this.StatusCode(StatusCodes.Status200OK, walkDTOs);
            // return Ok(regionsDTO);
        }
        [HttpGet]
        [Route("GetWalk{Id:Guid}")]
        [ActionName("GetWalk{Id:Guid}")]
        public async Task<IActionResult> GetWalk(Guid Id)
        {
            var walk = await walkRepository.GetWalk(Id);
            if (walk == null)
            {
                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true;
                res.Message = "Successfully";
                res.Data = null;
                return this.StatusCode(StatusCodes.Status404NotFound, res);
            }
            else
            {
                var walkDTO = mapper.Map<Model.DTO.WalkDTO>(walk);
                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true;
                res.Message = "Successfully";
                res.Data = walkDTO;
                return this.StatusCode(StatusCodes.Status200OK, res);
                //return new JsonResult(Ok(regionDTO));
            }

        }

        [HttpPost]
        [Route("AddWalk")]
        public async Task<IActionResult> AddWalk(Model.DTO.AddWalkDTO addWalk)
        {
            //Request (DTO) to Domain Model
            var Walk = new Walk()
            {
                Name = addWalk.Name,
                Lenght = addWalk.Lenght,
                RegionId = addWalk.RegionId,
                WalkdifficultyId = addWalk.WalkdifficultyId
            };
            //Pass details to Repository
            Walk = await walkRepository.AddWalk(Walk);
            //Convert back to DTO
            var WalkDTO = new Model.DTO.AddWalkDTO
            {
                Name = Walk.Name,
                Lenght = Walk.Lenght,
                RegionId = Walk.RegionId,
                WalkdifficultyId = Walk.WalkdifficultyId
            };
            if (WalkDTO == null)
            {
                res.Code = Convert.ToInt32(HttpStatusCode.BadRequest);
                res.Status = true;
                res.Message = "Somthing Went to wrong";
                res.Data = WalkDTO;
                return this.StatusCode(StatusCodes.Status400BadRequest, res);
            }
            else
            {
                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true;
                res.Message = "Record Inserted Successfully";
                res.Data = WalkDTO;
                return this.StatusCode(StatusCodes.Status200OK, res);
            }
            //  return new JsonResult(Ok(regionDTO));
            // return CreatedAtAction(nameof(GetRegion), new {id =regionDTO.Id },  );
        }

        [HttpPut]
        [Route("UpdateWalk{Id:Guid}")]
        public async Task<IActionResult> UpdateWalk([FromRoute] Guid Id, [FromBody] Model.DTO.AddWalkDTO updateWalk)
        {
            //Request (DTO) to Domain Model
            var walk = new Walk()
            {
                Name = updateWalk.Name,
                Lenght = updateWalk.Lenght,
                RegionId = updateWalk.RegionId,
                WalkdifficultyId = updateWalk.WalkdifficultyId
            };
            //Pass details to Repository
            walk = await walkRepository.UpdateWalk(Id, walk);
            //Convert back to DTO

            if (walk == null)
            {
                res.Code = Convert.ToInt32(HttpStatusCode.NotFound);
                res.Status = true;
                res.Message = "Record Not Found";
                res.Data = null;
                return this.StatusCode(StatusCodes.Status404NotFound, res);
            }
            else
            {
                var walkDTO = new Model.DTO.AddWalkDTO
                {
                    Name = walk.Name,
                    Lenght = walk.Lenght,
                    WalkdifficultyId = walk.WalkdifficultyId,
                    RegionId = walk.RegionId
                };
                res.Code = Convert.ToInt32(HttpStatusCode.OK);
                res.Status = true;
                res.Message = "Record Updated Successfully";
                res.Data = walkDTO;
                return this.StatusCode(StatusCodes.Status200OK, res);
            }
            //  return new JsonResult(Ok(regionDTO));
            // return CreatedAtAction(nameof(GetRegion), new {id =regionDTO.Id },  );
        }

    }
}
