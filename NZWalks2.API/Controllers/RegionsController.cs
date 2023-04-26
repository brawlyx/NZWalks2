using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks2.API.Data;
using NZWalks2.API.Models.Domain;
using NZWalks2.API.Models.DTO;
using NZWalks2.API.Repositories;

namespace NZWalks2.API.Controllers
{

    //
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalks2DbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(NZWalks2DbContext dbContext, IRegionRepository regionRepository) 
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }


        //getall regions method is accessed by httpget keyword, GET: https://localhost:portnumber/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // get data from database - domain models
            var regions = await regionRepository.GetAllAsync();

            //map the domain to dtos
            var regionsDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }


            //return the DTOs

            return Ok(regionsDto);
        }

        //get single region (get region by id)
        //get: api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };
            return Ok(region);
        }


        [HttpPost]
        public async Task <IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)

        {
            //map or convert DTO to domain model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // use domain model to create region
            await dbContext.Regions.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync();

            //map domain model to dto
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDomainModel);

        }

        //updaate region
        [HttpPut]
        [Route("{id:Guid}")]

        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]UpdateRegionRequestDto updateRegionRequestDto)
        {
            //check if region exists
            var regionnnDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionnnDomainModel == null)
            {
                return NotFound();
            }

            //map Dto to domain model
            regionnnDomainModel.Code = updateRegionRequestDto.Code;
            regionnnDomainModel.Name = updateRegionRequestDto.Name;
            regionnnDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            //convert domain model to dto

            var regionDto = new RegionDto
            {
                Id = regionnnDomainModel.Id,
                Code = regionnnDomainModel.Code,
                Name = regionnnDomainModel.Name,
                RegionImageUrl = regionnnDomainModel.RegionImageUrl
            };
            return Ok(regionDto);
        }


        //delete
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (regionDomainModel == null)
            {
                return NotFound();

            }

            //delete the region
            dbContext.Regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync();

            //return deleted region back
            //map domain model to dto
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto);
        }
    }
}
