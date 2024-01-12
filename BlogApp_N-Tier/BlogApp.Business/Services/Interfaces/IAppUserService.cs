using BlogApp.Business.DTOs.AppUserDto;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Interfaces
{
    public interface IAppUserService
    {
        Task Register(RegisterDto registerDto);
        Task<TokenResponseDto> Login(LoginDto loginDto);
    }
}
