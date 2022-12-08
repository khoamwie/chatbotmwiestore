using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MwiesStore.Models;

namespace MwiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BillController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getSumMoney/{startdate}&{enddate}")]
        public async Task<IActionResult> getSumMoney(string startdate, string enddate)
        {
            var acc = from p in _context.Products
                      join bd in _context.BillDetails on p.Id equals bd.Product_id
                      join b in _context.Bills.Where(i => i.Status == 3 && i.Date >= DateTime.Parse(startdate) && i.Date <= DateTime.Parse(enddate)) on bd.Bill_id equals b.Id
                      select new
                      {
                          Total = bd.Number*p.Price 
                      };
            return Ok(acc);
        }

        [HttpGet]
        [Route("getSumMoneyMon/{year}&{mon}")]
        public async Task<IActionResult> getSumMoneyMon(string year, string mon)
        {
            var acc = from p in _context.Products 
                      join bd in _context.BillDetails on p.Id equals bd.Product_id
                      join b in _context.Bills.Where(i => i.Status == 3 && i.Date.ToString().StartsWith(year + "-" + mon + "-")) on bd.Bill_id equals b.Id
                      select new
                      {
                          Total = bd.Number * p.Price
                      };
            return Ok(acc);
        }

        [HttpGet]
        [Route("getSumMoneyEnd/{startdate}&{year}&{endmon}")]
        public async Task<IActionResult> getSumMoneyEnd(string startdate, string year, string endmon)
        {
            var acc = from p in _context.Products
                      join bd in _context.BillDetails on p.Id equals bd.Product_id
                      join b in _context.Bills.Where(i => i.Status == 3 && i.Date >= DateTime.Parse(startdate) && i.Date.ToString().StartsWith(year + "-" + endmon + "-")) on bd.Bill_id equals b.Id
                      select new
                      {
                          Total = bd.Number * p.Price
                      };
            return Ok(acc);
        }

        [HttpGet]
        [Route("getSumMoneyStart/{startdate}&{year}&{startmon}")]
        public async Task<IActionResult> getSumMoneyStart(string startdate, string year, string startmon)
        {
            var acc = from p in _context.Products
                      join bd in _context.BillDetails on p.Id equals bd.Product_id
                      join b in _context.Bills.Where(i => i.Status == 3 && i.Date <= DateTime.Parse(startdate) && i.Date.ToString().StartsWith(year + "-" + startmon + "-")) on bd.Bill_id equals b.Id
                      select new
                      {
                          Total = bd.Number * p.Price
                      };
            return Ok(acc);
        }

        [HttpGet]
        [Route("getIdByUserId/{userid}&{status}")]
        public  async Task<IActionResult> getIdByUserId(int userid, int status)
        {
            var acc = await _context.Bills.Where(i => i.User_id == userid && i.Status == status).SingleOrDefaultAsync();
            return Ok(acc);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> getAll()
        {
            var acc = await _context.Bills.Where(i => i.Status != 0).ToListAsync();
            return Ok(acc);
        }


        [HttpGet]
        [Route("getbyUserId/{user}")]
        public async Task<IActionResult> getbyUserId(int user)
        {
            var acc = await _context.Bills.Where(i => i.User_id == user && i.Status != 0).ToListAsync();
            return Ok(acc);
        }

        private async Task<IActionResult> addEmptyBill(int user_id)
        {
            try
            {
                var u = new Bills
                {
                    User_id = user_id,
                    Status = 0,
                    Date = DateTime.Now,
                    Address = ""
                };

                var acc = await _context.Bills.SingleOrDefaultAsync(i => i.Id == u.Id);
                if (acc == null)
                {
                    _context.Add(u);
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
        [Route("Payment/{bill}&{user}&{add}")]
        public async Task<ActionResult> Payment(int bill, int user, string add)
        {

            var acc = await _context.Bills.Where(i => i.Id == bill && i.User_id == user).SingleOrDefaultAsync();
            if (acc == null)
            {
                return NotFound();
            }
            acc.Date = DateTime.Now;
            acc.Status = 1;
            acc.Address = add;
            await _context.SaveChangesAsync();
            await addEmptyBill(user);
            return Ok();
        }

        [HttpPut]
        [Route("acceptOrder/{bill}&{user}")]
        public async Task<ActionResult> acceptOrder(int bill, int user)
        {

            var acc = await _context.Bills.Where(i => i.Id == bill && i.User_id == user).SingleOrDefaultAsync();
            if (acc == null)
            {
                return NotFound();
            }

            acc.Status = 2;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("rejectOrder/{bill}&{user}")]
        public async Task<ActionResult> rejectOrder(int bill, int user)
        {

            var acc = await _context.Bills.Where(i => i.Id == bill && i.User_id == user).SingleOrDefaultAsync();
            if (acc == null)
            {
                return NotFound();
            }

            acc.Status = 4;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        [Route("shipOrder/{bill}&{user}")]
        public async Task<ActionResult> shipOrder(int bill, int user)
        {

            var acc = await _context.Bills.Where(i => i.Id == bill && i.User_id == user).SingleOrDefaultAsync();
            if (acc == null)
            {
                return NotFound();
            }

            acc.Status = 3;

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
