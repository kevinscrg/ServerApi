using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServerApi.Dtos.UserDtos;
using ServerApi.Servicies.Exceptii;
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
            try { 
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            try { 
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
            }catch(UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser(CreateUserDto user)
        {
            try { 
            if(user.Parola != user.ConfirmareParola)
            {
                return BadRequest("Parolele nu coincid");
            }

            var userAdded = await _userService.AddUserAsync(user);
            return CreatedAtAction(nameof(GetUser), new { id = userAdded.Id }, userAdded);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult> LogIn(LogInUserDto loginDto)
        {
            try
            {
                var result = await _userService.LogIn(loginDto);
                return Ok(result);

            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, UpdateUserDto user)
        {
            try { 
                if (id != user.Id)
                {
                    return BadRequest();
                }
                if (user.Parola != user.ConfirmareParola)
                {
                    return BadRequest("Parolele nu coincid");
                }


                await _userService.UpdateUserAsync(user);

                return NoContent();
            }
            catch (UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try { 
            await _userService.DeleteUserAsync(id);
            return NoContent();
            }catch(UserNotFoundException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
