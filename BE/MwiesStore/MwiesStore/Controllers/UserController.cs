using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MwiesStore.Models;

namespace MwiesStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult<Users>> getAll()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Users>> GetbyID(int id)
        {
            var acc = await _context.Users.Where(d => d.Id == id).SingleOrDefaultAsync();
            if (acc == null)
                return NotFound();
            return Ok(acc);
        }

        [HttpPost]
        [Route("addUser")]
        public async Task<IActionResult> addUser(Users user)
        {
            try
            {
                var u = new Users
                {
                    Name = user.Name,
                    Gender = user.Gender,
                    Birthdate = user.Birthdate,
                    Phone = user.Phone,                
                    Lock = user.Lock,
                };

                var acc = await _context.Users.SingleOrDefaultAsync(i => i.Name == u.Name);
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


        //Thay doi thong tin ca nhan
        [HttpPut]
        [Route("updateUser/{id}")]
        public async Task<ActionResult> updateUser(Users user, int id)
        {

            var acc = await _context.Users.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }
            acc.Name = user.Name;
            acc.Gender = user.Gender;
            acc.Birthdate = user.Birthdate;
            acc.Phone = user.Phone;  
        //    acc.Address - user.Address;
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("deleteUser/{id}")]
        public async Task<ActionResult> deleteUser(int id)
        {
            var acc = await _context.Users.FindAsync(id);
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
