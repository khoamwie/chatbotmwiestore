using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MwiesStore.Models;

namespace MwiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<Products>> GetAll()
        {
            return Ok(await _context.Products.ToListAsync());
        }
       
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Products>> GetbyID(int id)
        {
            var product = await _context.Products.Where(d => d.Id == id).SingleOrDefaultAsync();
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        
        [HttpGet]
        [Route("GetbyCategoryID")]
        public async Task<ActionResult<IEnumerable<Products>>> GetbyCategoryID(int id)
        {
            var product = await _context.Products.Where(d => d.Category_id == id).ToListAsync();
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpGet]
        [Route("GetbyBrandID")]
        public async Task<ActionResult<IEnumerable<Products>>> GetbyBrandID(int id)
        {
            var product = await _context.Products.Where(d => d.Brand_id == id).ToListAsync();
            if (product == null)
                return NotFound();
            return Ok(product);
        } 
    }
}
