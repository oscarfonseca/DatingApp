using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : ApiBaseController
    {
        private readonly DataContext _context;
        public AccountController(DataContext dataContext)
        {
            _context = dataContext;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(RegisterDto registerDto)
        {

            if (await UserExists(registerDto.Username))
                return BadRequest("Username already exists!");

            using var hmac = new HMACSHA512();
            var user = new AppUser{
                UserName = registerDto.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            _context.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        private Task<bool> UserExists(string username) 
             => _context.Users.AnyAsync(x => x.UserName == username.ToLower());

    }
}