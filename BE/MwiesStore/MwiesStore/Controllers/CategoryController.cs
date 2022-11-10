using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MwiesStore.Models;

namespace MwiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {   
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<Categories>> getAll()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Brands>> GetbyID(int id)
        {
            var acc = await _context.Categories.Where(d => d.Id == id).SingleOrDefaultAsync();
            if (acc == null)
                return NotFound();
            return Ok(acc);
        }

        [HttpPost]
        [Route("addCategory")]
        public async Task<IActionResult> addCategory(Categories category)
        {
            try
            {
                var c = new Categories
                {
                    Name = category.Name,
                };

                var ac = await _context.Categories.SingleOrDefaultAsync(i => i.Name == c.Name);
                if (ac == null)
                {
                    _context.Add(c);
                    _context.SaveChanges();
                    return Ok();
                }

                return BadRequest("Them khong thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("updateCategory/{id}")]
        public async Task<ActionResult> updateCategory(Categories category, int id)
        {

            var acc = await _context.Categories.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }
            acc.Name = category.Name;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteCategory/{id}")]
        public async Task<ActionResult> deleteCategory(int id)
        {
            var acc = await _context.Categories.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }
            _context.Remove(acc);
            _context.SaveChanges();
            return Ok();
        }
    }
}
