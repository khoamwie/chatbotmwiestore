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

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<Users>> Login([FromBody] Login l)
        {
            var acc = await _context.Users.Where(d => d.Username == l.username && d.Password == l.password).SingleOrDefaultAsync();

            if (acc != null)
            {
                return Ok(acc);
            }
            return BadRequest("Tai khoan hoac mat khong dung");

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
                    Lock = 0,
                    Role = 0,
                    Username = user.Username,
                    Password = user.Password,
                };

                

                var acc = await _context.Users.SingleOrDefaultAsync(i => i.Username == u.Username);
                if (acc == null)
                {
                    _context.Add(u);                    
                    _context.SaveChanges();
                    await addEmptyBill(u.Id);
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
        //khoa tai khoan nguoi dung
        [HttpPut]
        [Route("lockUser/{id}")]
        public async Task<ActionResult> lockUser(int id)
        {

            var acc = await _context.Users.FindAsync(id);
            if (acc == null)
            {
                return NotFound();
            }
            acc.Lock = 1;
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
    }
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
    }

}
