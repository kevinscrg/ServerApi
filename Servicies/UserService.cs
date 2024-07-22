using AutoMapper;
using ServerApi.Dtos;
using ServerApi.Dtos.CreateDtos;
using ServerApi.Dtos.UpdateDtos;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;
using ServerApi.Servicies.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace ServerApi.Servicies
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> AddUserAsync(CreateUserDto user)
        {
            var encryptedPass = this.EncryptPass(user.Parola);
            user.Parola = await encryptedPass;
            var userToAdd = _mapper.Map<User>(user);
            var userAdded = await _userRepository.AddUserAsync(userToAdd);
            return _mapper.Map<UserDto>(userAdded);
        }

        public async Task UpdateUserAsync(UpdateUserDto user)
        {
            var userToUpdate = await _userRepository.GetUserByIdAsync(user.Id);

            if (userToUpdate == null) throw new Exception("User not found");
            

            userToUpdate.Nume = user.Nume;
            userToUpdate.Parola = user.Parola;

            await _userRepository.UpdateUserAsync(userToUpdate);

        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        

        private Task<string> EncryptPass(string pass)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(pass));

            var sb = new StringBuilder();
            for(int i =0; i< bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return Task.FromResult(sb.ToString());
        }
    }
}
