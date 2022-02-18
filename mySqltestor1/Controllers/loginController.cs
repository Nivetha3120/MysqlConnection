
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace mySqltestor1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class loginController : ControllerBase
    {
        private readonly AppContext _context;
        public loginController()
        {
            _context = new AppContext();
        }

        [HttpGet("/api/Companies")]
        //public dynamic All() => _context.Admin_login;
        public IEnumerable<admin_login> GetCustomerDetails()        
        {
            return _context.Admin_login.ToList();
        }

         [HttpGet("GetAccountNumber")]
        public admin_login GetAccountNumber(int ID)
        {
            return _context.Admin_login.Find(ID);
        }
        [HttpPost("InsertCustomer")]
        public IActionResult InsertCustomer([FromBody] admin_login context)
        {
            if (context.ID.ToString() != "")
            {
                _context.Admin_login.Add(context);
                _context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] admin_login context)
        {
            if (context.ID.ToString() != "")
            {
                _context.Entry(context).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok("Customer Details updated successfully!");
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(int ID)
        {
            //select * from CustomerDetails where AccountNumber=123
            var result = _context.Admin_login.Find(ID);
            if (result != null)
            {
                _context.Admin_login.Remove(result);
                _context.SaveChanges();
                return Ok("Deleted Successfully");
            }
            else
            {
                return NotFound("Invalid Account number");
            }

        }
       // [HttpGet("/api/Companies/{id}")]
       // public dynamic Get(int id) => _context.Admin_login.SingleOrDefault(c => c.ID == id);
    }
}