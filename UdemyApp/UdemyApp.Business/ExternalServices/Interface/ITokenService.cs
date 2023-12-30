using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.UserDtos;
using UdemyApp.Core.Entities;

namespace UdemyApp.Business.ExternalServices.Interface
{
    public interface ITokenService
    {
        TokenResponseDto CreateToken(AppUser user, int expireDate=60);
    }
}
