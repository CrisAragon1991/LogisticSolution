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
    public class DeliveryScheduleController : ControllerBase
    {
        private readonly DeliveryScheduleRepository deliveryScheduleRepository;

        public DeliveryScheduleController(ApplicationDbContext context)
        {
            deliveryScheduleRepository = new DeliveryScheduleRepository(context);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliverySchedule>>> Get([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validPageFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, 1);
                var deliveries = await deliveryScheduleRepository.GetEntityWithPaginationFilter(validPageFilter);
                return new ActionResult<IEnumerable<DeliverySchedule>>(deliveries);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);  
            }
        }

        // GET api/<DeliveryScheduleController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliverySchedule>> Get(int id)
        {
            try
            {
                return new ActionResult<DeliverySchedule>(await deliveryScheduleRepository.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<DeliveryScheduleController>
        [HttpPost]
        public async Task<ActionResult<DeliverySchedule>> Post([FromBody] DeliveryScheduleDto deliverySchedule)
        {
            try
            {
                return new ActionResult<DeliverySchedule>(await deliveryScheduleRepository.CreateNewDeliverySchedule(deliverySchedule));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<DeliveryScheduleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DeliverySchedule>> Put(int id, [FromBody] DeliveryScheduleDto deliverySchedule)
        {
            try
            {
                return new ActionResult<DeliverySchedule>(await deliveryScheduleRepository.UpdateDeliverySchedule(id, deliverySchedule));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<DeliveryScheduleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var updated = await deliveryScheduleRepository.DeleteEntityById(id);
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
