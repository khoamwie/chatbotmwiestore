using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MwiesStore.Models;

namespace MwiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ImageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<Images>> GetAll()
        {
            return Ok(await _context.Images.ToListAsync());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Images>> GetbyID(int id)
        {
            var acc = await _context.Images.Where(d => d.Product_id == id).ToListAsync();
            if (acc == null)
                return NotFound();
            return Ok(acc);
        }

        [HttpPost]
        [Route("addImage")]
        public async Task<IActionResult> addImage(Images images)
        {
            try
            {
                var b = new Images
                {
                    Url = images.Url,
                    Product_id = images.Product_id,
                };

                var acc = await _context.Images.SingleOrDefaultAsync(i => i.Id == b.Id);
                if (acc == null)
                {
                    _context.Add(b);
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
        [Route("updateImage/{id}")]
        public async Task<ActionResult> updateImage(Images images, int id)
        {

            var acc = await _context.Images.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }
            acc.Url = images.Url;
            acc.Product_id = images.Product_id;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteImage/{id}")]
        public async Task<ActionResult> deleteImage(int id)
        {
            var acc = await _context.Images.FindAsync(id);
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
