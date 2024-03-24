using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Entity;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly DataContext _context;

        public ItemController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<Item>> GetAllItems()
        {
            var items = await _context.items.ToListAsync();

            return Ok(items);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<Item>>> GetItem(int id)
        {
            var item = await _context.items.FindAsync(id);
            if (item is null) {
                return BadRequest("Item not found");
            }
            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<List<Item>>> Addtem(Item item)
        {
            _context.items.Add(item);
            await _context.SaveChangesAsync();
           
            return Ok();
        }


        [HttpPut]
        public async Task<ActionResult<List<Item>>> Updateitem(Item updatedItem)
        {
            var dbItem = await _context.items.FindAsync(updatedItem.id);
            if (dbItem is null)
            {
                return BadRequest("Item not found");
            }

            dbItem.name = updatedItem.name;
            dbItem.description = updatedItem.description;

            await _context.SaveChangesAsync();


            return Ok();
        }


    
        [HttpDelete("{id}")]

        public async Task<ActionResult<List<Item>>> DeleteItem (int id)
        {
            var item = await _context.items.FindAsync(id);
            if (item is null)
            {
                return BadRequest("Item not found");
            }
            _context.items.Remove(item);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
 