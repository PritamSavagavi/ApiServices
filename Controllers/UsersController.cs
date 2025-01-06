using ApiServices.Data;
using ApiServices.Models;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;

namespace ApiServices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            if (_context.Users is null) return NotFound();
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            //return _context.Users.FirstOrDefault(a => a.Id = id);
            var user = _context.Users?.FirstOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound(); // HTTP 404
            }

            return user;
        }
    }
}