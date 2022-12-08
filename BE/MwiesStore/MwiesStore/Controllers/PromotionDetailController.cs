using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MwiesStore.Models;

namespace MwiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PromotionDetailController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("CheckPromotion/{product}")]
        public async Task<IActionResult> CheckPromotion(int product)
        {
            var acc = from pmd in _context.PromotionDetails
                      join p in _context.Products.Where(i => i.Id == product) on pmd.Product_Id equals p.Id
                      join pm in _context.Promotions.Where(i => i.StartDate < DateTime.Now && i.EndDate > DateTime.Now) on pmd.Promotion_Id equals pm.Id
                      select new
                      {
                          Discount = pm.Discount
                      };
            return Ok(acc);
        }
    }
}
