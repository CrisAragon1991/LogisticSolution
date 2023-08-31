using LogisticSolution.Data;
using LogisticSolution.DTOs;
using LogisticSolution.Models;
using LogisticSolution.Repositories.BaseRepository;
using LogisticSolution.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace LogisticSolution.Repositories
{
    public class UserRepository : BaseRepository<User> 
    {
        private readonly IConfiguration config;
        public UserRepository(ApplicationDbContext context, IConfiguration configuration): base(context)
        {
            this.config = configuration;
        }

        public async Task<User> SignUp(UserDto user) 
        {
            byte[] passwordEncripted;
            byte[] salt;
            Utilities.CreatePasswordHash(user.Password, out passwordEncripted, out salt);
            var newUser = new User
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                PasswordSalt = salt,
                Password = passwordEncripted,
                Role = user.Role
            };
            await this.CreateEntity(newUser);
            return newUser;
        }

        public async Task<UserDto> Login(LoginDto login)
        {
            var user = await dbContext?.Users?.FirstOrDefaultAsync(u => u.Email == login.Email);
            if (user == null)
            {
                return null;
            }
            bool validCredentials = Utilities.VerifyPasswordHash(login.Password, user.Password, user.PasswordSalt);
            if (validCredentials)
            {
                var token = Utilities.CreateToken(user, config);
                var newDto = new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,
                    LastName = user.LastName,
                    Email = user.Email,
                    Token = token,
                    Role = user.Role
                };
                return newDto;
            } else
            {
                return null;
            }
        }
    }
}
