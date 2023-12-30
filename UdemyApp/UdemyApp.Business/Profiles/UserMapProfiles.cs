using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyApp.Business.DTOs.UserDtos;
using UdemyApp.Core.Entities;

namespace UdemyApp.Business.Profiles
{
    public class UserMapProfiles:Profile
    {
        public UserMapProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<RegisterDto, AppUser>().ReverseMap();
        }
    }
}
