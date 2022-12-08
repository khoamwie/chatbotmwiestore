using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MwiesStore.Models;

namespace MwiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillDetailController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BillDetailController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getBillDetail/{bill}&{user}&{status}")]
        public async Task<IActionResult> getBillDetail(int bill, int user, int status)
        {
            var acc = from p in _context.Products
                      join bd in _context.BillDetails on p.Id equals bd.Product_id
                      join b in _context.Bills.Where(i => i.Id == bill && i.Status == status) on bd.Bill_id equals b.Id
                      join u in _context.Users.Where(i => i.Id == user) on b.User_id equals u.Id
                      select new { 
                          IdSanPham = p.Id,
                          TenSanPham  = p.Name, 
                          SoLuong = bd.Number, 
                          Gia = p.Price*bd.Number, 
                          bd.Bill_id, 
                          u.Id, 
                          b.Status
                      };
            return Ok(acc);
        }

        //[HttpGet]
        //[Route("getAllBill/{status}")]
        //public async Task<IActionResult> getAllBill(int status)
        //{
        //    var acc = from p in _context.Products
        //              join bd in _context.BillDetails on p.Id equals bd.Product_id
        //              join b in _context.Bills.Where(i => i.Status == status) on bd.Bill_id equals b.Id
        //              join u in _context.Users on b.User_id equals u.Id
        //              select new
        //              {
        //                  IdSanPham = p.Id,
        //                  TenSanPham = p.Name,
        //                  SoLuong = bd.Number,
        //                  Gia = p.Price * bd.Number,
        //                  bd.Bill_id,
        //                  u.Id,
        //                  b.Status,
        //                  b.Address
        //              };
        //    return Ok(acc);
        //}

        //[HttpGet]
        //[Route("getAll")]
        //public async Task<IActionResult> getAll()
        //{
        //    return Ok(await _context.BillDetails.ToListAsync());
        //}

        [HttpGet]
        [Route("getBillIdbyId")]
        public async Task<IActionResult> getBillIdbyId(int id)
        {
            var acc = await _context.BillDetails.Where(x => x.Id == id).SingleOrDefaultAsync();
            return Ok(acc);
        }

        [HttpPost]
        [Route("addCard")]
        public async Task<IActionResult> addCard(BillDetails bd)
        {
            try
            {
                var u = new BillDetails
                {
                    Product_id = bd.Product_id,
                    Bill_id = bd.Bill_id,
                    Number = bd.Number,
                };

                var acc = await _context.BillDetails.SingleOrDefaultAsync(i => i.Id == u.Id);
                if (acc == null)
                {
                    var bcc = await _context.Bills.Where(i => i.Status == 0 && i.Id == u.Bill_id).SingleOrDefaultAsync();
                    if(bcc != null)
                    {
                        _context.Add(u);
                        _context.SaveChanges();
                        return Ok();
                    }   
                }

                return BadRequest("Them khong thanh cong");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("UpdateNumberCard/{bill}&{product}&{number}")]
        public async Task<ActionResult> UpdateNumberCard(int bill, int product, int number)
        {

            var acc = await _context.BillDetails.Where(i => i.Bill_id == bill && i.Product_id == product).SingleOrDefaultAsync();

            acc.Number = number;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteCard/{bill}&{product}")]
        public async Task<ActionResult> deleteCard(int bill, int product)
        {
            var acc = await _context.BillDetails.Where(i => i.Bill_id == bill && i.Product_id == product).SingleOrDefaultAsync();
            
            if(acc == null)
            {
                return NotFound();
            }
            _context.Remove(acc);
            _context.SaveChangesAsync();
            return Ok();
        }

    }
}
