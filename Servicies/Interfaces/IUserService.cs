using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;

namespace ServerApi.Servicies.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> AddUserAsync(CreateUserDto user);
        Task UpdateUserAsync(UserDto user);
        Task DeleteUserAsync(int id);
    }
}
