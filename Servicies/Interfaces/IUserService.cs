using ServerApi.Dtos.UserDtos;
using System.IdentityModel.Tokens.Jwt;

namespace ServerApi.Servicies.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> AddUserAsync(CreateUserDto user);
        Task UpdateUserAsync(UpdateUserDto user);
        Task DeleteUserAsync(int id);

        Task<string> LogIn(LogInUserDto loginDto);

    }
}
