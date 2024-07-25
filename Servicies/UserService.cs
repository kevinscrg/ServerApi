using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ServerApi.Dtos.UserDtos;
using ServerApi.Models;
using ServerApi.Repositories.Interfaces;
using ServerApi.Servicies.Exceptii;
using ServerApi.Servicies.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ServerApi.Servicies
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
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
            if(await _userRepository.SearchUserByEmailAsync(user.Email)) throw new UserExistsException("User already exists");

            var encryptedPass = this.EncryptPassAsync(user.Parola);
            user.Parola = await encryptedPass;
            var userToAdd = _mapper.Map<User>(user);
            var userAdded = await _userRepository.AddUserAsync(userToAdd);
            return _mapper.Map<UserDto>(userAdded);
        }

        public async Task UpdateUserAsync(UpdateUserDto user)
        {
          if(! await _userRepository.SearchUserByEmailAsync(user.Email)) throw new UserNotFoundException("User not found");  
            var EncryptedPass = await EncryptPassAsync(user.Parola);
            user.Parola = EncryptedPass;
            var userToUpdate = _mapper.Map<User>(user);


            await _userRepository.UpdateUserAsync(userToUpdate);

        }

        public async Task DeleteUserAsync(int id)
        {
            await _userRepository.DeleteUserAsync(id);
        }

        

        private Task<string> EncryptPassAsync(string pass)
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

        public async Task<string> LogIn(LogInUserDto loginDto)
        {
          
            var user = await _userRepository.GetUserByEmailAsync(loginDto.Email);

            if (user == null) throw new UserNotFoundException("User not found");
            var encryptedPass = await EncryptPassAsync(loginDto.Parola);
            if(user.Parola != encryptedPass) throw new Exception("Incorrect password");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,  _configuration["Jwt:Subject"]),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                //new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToString()), -- aici genereaza un token gresit
                new Claim("Id", user.Id.ToString()),
                new Claim("Email", user.Email.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signIn
            );
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }

    }
}
