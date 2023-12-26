using BlogApp.Business.DTOs.AppUserDto;
using BlogApp.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAppUserService _Service;

        public UserController(IAppUserService service)
        {
            _Service = service;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {
       
            var result =  _Service.Register(registerDto);
            if (result.Succeeded)
            {
                return Ok("Registrated successfully!");
            }

            return BadRequest(result.Errors);
        }
    }
}
