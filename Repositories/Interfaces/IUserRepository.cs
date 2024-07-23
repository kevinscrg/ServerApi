using ServerApi.Models;

namespace ServerApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

        Task<User> GetUserByEmailAsync(string email);
        Task<bool> SearchUserByEmailAsync(string email);
    }
}
