using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Entity;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<User>> GetAllUsers()
        {
            var users = await _context.users.ToListAsync();

            return Ok(users);
        }

        [HttpGet("fromQuery")]

        public async Task<ActionResult<User>> GetUser([FromQuery] int id)
        {
            var users = await _context.users.FindAsync(id);
            if (users is null)
            {
                return BadRequest("user not found");
            }
            return Ok(users);
        }

        [HttpPost("fromBody")]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            _context.users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult<User>> Updateitem(User updateUser)
        {
            var dbUser = await _context.users.FindAsync(updateUser.id);
            if (dbUser is null)
            {
                return BadRequest("User not found");
            }

            dbUser.name = updateUser.name;
            dbUser.surname = updateUser.surname;
            dbUser.iditem = updateUser.iditem;

            await _context.SaveChangesAsync();


            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user is null)
            {
                return BadRequest("User not found");
            }
            _context.users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
