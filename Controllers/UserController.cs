using Microsoft.AspNetCore.Mvc;
using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Dtos.UpdateDtos;
using ServerApi.Servicies.Interfaces;

namespace ServerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto user)
        {
            var userAdded = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = userAdded.Id }, userAdded);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto user)
        {
            try { 
                if (id != user.Id)
                {
                    return BadRequest();
                }

                await _userService.UpdateUserAsync(user);

                return NoContent();
            }catch(System.Exception e)
                {
                    return NotFound(e.Message);
                }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return NoContent();
        }


    }
}
