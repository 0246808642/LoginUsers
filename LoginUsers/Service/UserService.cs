using AutoMapper;
using LoginUsers.Data.Dtos.UserDtos;
using LoginUsers.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginUsers.Service
{
    public class UserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _singInManager;
        private readonly TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _singInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task RegisterAsync(CreateUserDto create)
        {
            var user = _mapper.Map<User>(create);
            var result = await _userManager.CreateAsync(user, create.Password);
            if (!result.Succeeded)
            {
                throw new ApplicationException($"Falha ao cadastrar {create.Username}!");
            }
        }

        public async Task<string> Login(LoginUserDto dto)
        {
            var result = await _singInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);
            if (!result.Succeeded)
            {
                throw new ApplicationException($"Falha ao autenticar {dto.Username}!");
            }
            var user =  _singInManager.UserManager.Users.FirstOrDefault(x=>x.NormalizedUserName == dto.Username.ToUpper());
           var token = _tokenService.GenerateToken(user);
            return token;
        }
    }
}

