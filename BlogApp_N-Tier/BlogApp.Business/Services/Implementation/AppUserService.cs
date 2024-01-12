using AutoMapper;
using BlogApp.Business.DTOs.AppUserDto;
using BlogApp.Business.Exceptions.User;
using BlogApp.Business.ExternalServices.Interface;
using BlogApp.Business.Services.Interfaces;
using BlogApp.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Implementation
{
    public class AppUserService:IAppUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ITokenService _tokenService { get; }

        public AppUserService(UserManager<AppUser> userManager, IMapper mapper, ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }


        public async Task Register(RegisterDto registerDto)
        {
            if (registerDto == null) throw new RegistrationException();
            AppUser user = _mapper.Map<AppUser>(registerDto);
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                if (result.Errors.Any()) throw new RegistrationException();
            };

        }
        public async Task<TokenResponseDto> Login(LoginDto loginDto)
        {
            var identityUser = await _userManager.FindByNameAsync(loginDto.UserNameorEmail) ?? await _userManager.FindByEmailAsync(loginDto.UserNameorEmail);
            if (identityUser == null) throw new RegistrationException();
            if (!await _userManager.CheckPasswordAsync(identityUser, loginDto.Password)) throw new RegistrationException();

            return _tokenService.CreateToken(identityUser);
        }

    }
}
