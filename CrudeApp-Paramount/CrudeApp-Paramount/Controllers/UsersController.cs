using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudeApp_Paramount.Models;
using CrudeApp_Paramount.Services;

namespace CrudeApp_Paramount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseService _dbService;

        public UsersController(IConfiguration configuration)
        {
            _dbService = new DatabaseService(configuration.GetConnectionString("DefaultConnection"));
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _dbService.GetUsers();
            return Ok(users);
        }

        [HttpPost]                                                          //->insert
        public IActionResult InsertUser(User user)
        {
            _dbService.ManageUser(user, 'i');
            return Ok("Hi Sujit, Paramount user inserted successfully.");
        }

        [HttpPut]                                                           //->Update
        public IActionResult UpdateUser(User user)
        {
            _dbService.ManageUser(user, 'u');
            return Ok("Hi Sujit, Paramount user updated successfully.");
        }

        [HttpDelete("{id}")]                                                //->delete
        public IActionResult DeleteUser(int id)
        {
            var user = new User { UserId = id };
            _dbService.ManageUser(user, 'd');
            return Ok("Hi Sujit, Paramount user deleted successfully.");
        }
    }
}
