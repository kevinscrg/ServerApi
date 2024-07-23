using ServerApi.Dtos.UserDtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> AddUserAsync(CreateUserDto user);
        Task UpdateUserAsync(UpdateUserDto user);
        Task DeleteUserAsync(int id);

        Task<bool> LogIn(LogInUserDto loginDto);

    }
}
