using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : ApiBaseController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsersAsync() => await _context.Users.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id) => await _context.Users.FindAsync(id);
    }
}