using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Data;

namespace WebAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly DataContext _context;
        public HumanController(DataContext context) 
        {
            _context = context; 
        }

        [HttpPost]
        public async Task<ActionResult<List<Human>>> AddHuman(Human human)
        {
            _context.Humans.Add(human);
            await _context.SaveChangesAsync();

            return Ok(await _context.Humans.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Human>>> GetAllHumans()
        {
            return Ok(await _context.Humans.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Human>>> GetHuman(int id)
        {
            var human = await _context.Humans.FindAsync(id);
            if (human == null)
            {
                return BadRequest("Human not found.");
            }
            return Ok(human);
        }
    }
}
