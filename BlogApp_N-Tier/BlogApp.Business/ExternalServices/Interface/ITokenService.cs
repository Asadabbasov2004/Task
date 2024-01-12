using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogApp.Business.DTOs.AppUserDto;
using BlogApp.Core.Entities;

namespace BlogApp.Business.ExternalServices.Interface
{
    public interface ITokenService
    {
        TokenResponseDto CreateToken(AppUser user, int expireDate=60);
    }
}
