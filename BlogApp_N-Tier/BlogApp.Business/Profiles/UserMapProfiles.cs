using AutoMapper;
using BlogApp.Business.DTOs.AppUserDto;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyApp.Business.Profiles
{
    public class UserMapProfiles:Profile
    {
        public UserMapProfiles()
        {
            CreateMap<RegisterDto, AppUser>().ReverseMap();
        }
    }
}
