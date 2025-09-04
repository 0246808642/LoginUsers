using AutoMapper;
using LoginUsers.Data.Dtos.UserDtos;
using LoginUsers.Models;
using Microsoft.AspNetCore.Identity;

namespace LoginUsers.Service
{
    public class RegisterService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public RegisterService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
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
    }
}

