using EcommerceAPI.Models;
using EcommerceAPI.Services;
using Microsoft.AspNetCore.Mvc;



namespace EcommerceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<UserDto> listUsers = new List<UserDto>() {
            new UserDto()
            {
                FirstName = "Jacob",
                LastName = "Harvey",
                Email = "test.com",
                Phone = "1234564444",
                Address = "New York, USA"
            },
            new UserDto()
            {
                FirstName = "Natasha",
                LastName = "Hall",
                Email = "testing.com",
                Phone = "1234565555",
                Address = "New York, USA"
            }
        };

        [HttpGet("Info")]
        public IActionResult GetInfo(int? id, string? name, int? page,
            [FromServices]IConfiguration config,
            [FromServices]TimeService timeService
        )
        {
            if(id != null || name != null || page != null)
            {
                var response = new
                {
                    Id = id,
                    Name = name,
                    Page = page,
                    ErrorMesage = "The search functionality is not supported yet"
                };
                return Ok(response);
            }

            List<string> listInfo = new List<string>
            {
                "AppName=" + config["AppName"],
                "Language=" + config["Language"],
                "Country=" + config["Country"],
                "Log=" + config["Logging:LogLevel:Default"],
                "Date=" + timeService.GetDate(),
                "Time=" + timeService.GetTime()
            };

            return Ok(listInfo);
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            if(listUsers.Count > 0)
            {
                return Ok(listUsers);
            }

            return NoContent();
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUser(int id)
        {
            if(id >= 0 && id < listUsers.Count)
            {

            return Ok(listUsers[id]);
            }

            return NotFound();
        }

        [HttpGet("{name}")]
        public IActionResult GetUser(string name)
        {
            var user = listUsers.FirstOrDefault(
                u => u.FirstName.Contains(name) || u.LastName.Contains(name)
            );

            if(user  == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser(UserDto user)
        {
            // Check if the EmailAddress is Authorized
            if (user.Email.Equals("user@example.com"))
            {
                ModelState.AddModelError("Email", "This Email Address is not authorized");
                return BadRequest(ModelState);
            }

            listUsers.Add(user);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserDto user)
        {
             // Check if the EmailAddress is Authorized
            if (user.Email.Equals("user@example.com"))
            {
                ModelState.AddModelError("Email", "This Email Address is not authorized");
                return BadRequest(ModelState);
            }

            if(id > 0 && id < listUsers.Count)
            {
                listUsers[id] = user;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if(id > 0 && id < listUsers.Count)
            {
                listUsers.RemoveAt(id);
            }

            return NoContent();
        }
    }
}
