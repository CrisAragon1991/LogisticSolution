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
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;
        public UserController(ApplicationDbContext context, IConfiguration config)
        {
            userRepository = new UserRepository(context, config);
        }
        // GET: api/<UserController>
        [Authorize(Policy = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get([FromQuery] PaginationFilter filter)
        {
            try
            {
                var validPageFilter = new PaginationFilter(filter.PageNumber, filter.PageSize, 1);
                return new ActionResult<IEnumerable<User>>(await userRepository.GetEntityWithPaginationFilter(validPageFilter));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<UserController>/5
        [Authorize(Policy = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            try
            {
                return new ActionResult<User>(await userRepository.GetEntityById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<UserController>
        [HttpPost("sign-up")]
        public async Task<ActionResult<User>> Post([FromBody] UserDto userDto)
        {
            try
            {
                return new ActionResult<User>(await userRepository.SignUp(userDto));
            } catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] LoginDto login)
        {
            try
            {
                var user = await userRepository.Login(login);
                if (user == null)
                {
                    return StatusCode(401, "Not Authorized");
                }
                else
                {
                    return new ActionResult<UserDto>(user);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
