using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.UserDtos;
using UdemyApp.Business.Exceptions.User;
using UdemyApp.Business.ExternalServices.Interface;
using UdemyApp.Business.Services.Interface;
using UdemyApp.Core.Entities;

namespace UdemyApp.Business.Services.Implemantations
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public ITokenService _tokenService { get; }

        public UserService(UserManager<AppUser> userManager ,IMapper mapper ,ITokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }


        public async Task Register(RegisterDto registerDto)
        {
            if(registerDto == null) throw new RegistrationException() ;
            AppUser user = _mapper.Map<AppUser>(registerDto);
          var result=await _userManager.CreateAsync(user,registerDto.Password);
            
            if (!result.Succeeded)
            {
                if (result.Errors.Any()) throw new RegistrationException();
            };

        }
        public async Task<TokenResponseDto> Login(LoginDto loginDto)
        {
            var identityUser = await _userManager.FindByNameAsync(loginDto.UserNameorEmail)??await _userManager.FindByEmailAsync(loginDto.UserNameorEmail);
            if (identityUser == null) throw new RegistrationException();
            if (!await _userManager.CheckPasswordAsync(identityUser, loginDto.Password)) throw new RegistrationException();

            return _tokenService.CreateToken(identityUser);
        }
      
        }
    }

