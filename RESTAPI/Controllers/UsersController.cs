using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
namespace RESTAPI.Controllers
{
   
    [Route("api/Users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       

        private UserService _UserService = new UserService(Startup.DatabasePath);
        // GET: api/Users

        [HttpGet("GetAll")]
        public async Task<List<User>> GetAll()
        {
            return  await _UserService.Get();
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var User = await _UserService.getUserByID(id);
            if (User == null) {
                return NotFound();
            }
            return User;
        }


        // GET: api/Users/5
        [HttpPost("checkLogin")]
        public async Task<ActionResult<User>> checkLogin()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            var User = await _UserService.CheckLogin(username, password);
            if (User == null)
            {
                return NotFound();
            }
            return User;
        }

        // POST: api/Users
        [HttpPost("AddUser")]
        public async Task<int> AddUser([FromBody] User item){
         
            _UserService.user = item;
            var result = await _UserService.Insert();
            return result;
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("DeleteUser/{id}")]
        public async Task<int> DeleteUser(int id)
        {
           return await _UserService.DeleteUser(id);
        }
    }
}
