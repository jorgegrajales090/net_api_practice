using LearningAPI.Application.Interfaces.Services;
using LearningAPI.Data;
using LearningAPI.Domain.Users;

//using LearningAPI.Data.Models;
using LearningAPI.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : Controller
    {

        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Get(string user, string password)
        {
            var userData = _userService.GetUserByEmailAndPassword(user, password);

            if (userData == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(userData);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto userData)
        {

            if (userData == null)
            {
                return BadRequest();
            }

            var user = new User()
            {
                Id = Guid.NewGuid(),
                Email = userData.Email,
                Password = userData.Password,
                Name = userData.Name,
                Age = userData.Age
            };

            var result = _userService.CreateUser(user);

            if (result) return Created();
            else return BadRequest();

        }

        [HttpPut]
        public IActionResult Put([FromBody] UserDto userData, Guid userId)
        {
            if (userData == null)
            {
                return BadRequest();
            }

            var user = new User()
            {
                Name = userData.Name,
                Age = userData.Age,
                Email = userData.Email,
                Password = userData.Password
            };

            var result = _userService.UpdateUser(user, userId);

            if (result) return NoContent();
            else return BadRequest();

        }

        [HttpDelete]
        public IActionResult Delete(Guid userId)
        {
            var result = _userService.DeleteUser(userId);

            if (result) return NoContent();
            else return BadRequest();

        }
    }
}
