using ApiServices.Data;
using ApiServices.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace ApiServices.Controllers
{
    public class UsersController(DataContext context) : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            if (context.Users is null) return NotFound();
            return  await context.Users.ToListAsync();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user is null) return NotFound(); // HTTP 404
            return Ok(user);
        }
    }
}