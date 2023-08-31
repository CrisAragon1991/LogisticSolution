using LogisticSolution.Data;
using LogisticSolution.DTOs;
using LogisticSolution.Models;
using LogisticSolution.Repositories;
using LogisticSolution.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogisticSolution.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly LocationRepository locationRepository;
        public LocationController(ApplicationDbContext context)
        {
            locationRepository = new LocationRepository(context);
        }
        // GET: api/<LocationController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> Get([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validPageFilter = new PaginationFilter(filter.PageNumber, filter.PageSize,1);
                return new ActionResult<IEnumerable<Location>>(await locationRepository.GetEntityWithPaginationFilter(validPageFilter));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<LocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> Get(int id)
        {
            try
            {
                return new ActionResult<Location>(await locationRepository.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<LocationController>
        [HttpPost]
        public async Task<ActionResult<Location>> Post([FromBody] LocationDto location)
        {
            try
            {
                var newLocation = new Location()
                {
                    LocationType = location.LocationType,
                    Name = location.Name
                };
                return new ActionResult<Location>(await locationRepository.CreateEntity(newLocation));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<LocationController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Location>> Put(int id, [FromBody] LocationDto location)
        {
            try
            {
                var newLocation = new Location()
                {
                    LocationId = id,
                    LocationType = location.LocationType,
                    Name = location.Name
                };
                return new ActionResult<Location>(await locationRepository.UpdateEntity(id,newLocation));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<LocationController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var updated = await locationRepository.DeleteEntityById(id);
                if (updated)
                {
                    return StatusCode(204);
                }
                else
                {
                    return StatusCode(404, "Resource Not Found");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
