
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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
       // [HttpGet("/api/Companies/{id}")]
       // public dynamic Get(int id) => _context.Admin_login.SingleOrDefault(c => c.ID == id);
    }
}