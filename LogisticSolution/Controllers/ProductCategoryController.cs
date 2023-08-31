using LogisticSolution.Data;
using LogisticSolution.DTOs;
using LogisticSolution.Models;
using LogisticSolution.Repositories;
using LogisticSolution.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LogisticSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly ProductCategoryRepository productCategoryRepository;
        public ProductCategoryController(ApplicationDbContext context)
        {
            productCategoryRepository = new ProductCategoryRepository(context);
        }
        // GET: api/<ProductCategoryController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductCategory>>> Get([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validPageFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, 1);
                return new ActionResult<IEnumerable<ProductCategory>>(await productCategoryRepository.GetEntityWithPaginationFilter(validPageFilter));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ProductCategoryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> Get(int id)
        {
            try
            {
                return new ActionResult<ProductCategory>(await productCategoryRepository.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ProductCategoryController>
        [HttpPost]
        public async Task<ActionResult<ProductCategory>> Post([FromBody] ProductCategoryDto productCategory)
        {
            try
            {
                var newProductCategory = new ProductCategory()
                {
                    Name = productCategory.Name
                };
                return new ActionResult<ProductCategory>(await productCategoryRepository.CreateEntity(newProductCategory));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ProductCategoryController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductCategory>> Put(int id, [FromBody] ProductCategoryDto productCategory)
        {
            try
            {
                var newProductCategory = new ProductCategory()
                {
                    ProductCategoryId = id,
                    Name = productCategory.Name
                };
                return new ActionResult<ProductCategory>(await productCategoryRepository.UpdateEntity(id, newProductCategory));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var updated = await productCategoryRepository.DeleteEntityById(id);
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
