using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MwiesStore.Models;

namespace MwiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly AppDbContext _context;
        public BrandController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<Brands>> GetAll()
        {
            return Ok(await _context.Brands.ToListAsync());
        }
        
        
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Brands>> GetbyID(int id)
        {
            var acc = await _context.Brands.Where(d => d.Id == id).SingleOrDefaultAsync();
            if (acc == null)
                return NotFound();
            return Ok(acc);
        }

        [HttpPost]
        [Route("addBrand")]
        public async Task<IActionResult> addBrand(Brands brands)
        {
            try
            {
                var b = new Brands
                {
                    Name = brands.Name,
                    Country = brands.Country,
                };

                var acc = await _context.Brands.SingleOrDefaultAsync(i => i.Name == b.Name);
                if (acc == null)
                {
                    _context.Add(b);
                    _context.SaveChanges();
                    return Ok();
                }

                return BadRequest("Them khong thanh cong");
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("updateBrand/{id}")]
        public async Task<ActionResult> updateBrand(Brands brands, int id)
        {

            var acc = await _context.Brands.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }
            acc.Name = brands.Name;
            acc.Country = brands.Country;     
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteBrand/{id}")]
        public async Task<ActionResult> deleteBrand(int id)
        {
            var acc = await _context.Brands.FindAsync(id);
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
