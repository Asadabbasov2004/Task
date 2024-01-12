using BlogApp.Business.DTOs.AppUserDto;
using BlogApp.Business.Exceptions.User;
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
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDto registerDto)
        {

            try
            {
                await _Service.Register(registerDto);
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (RegistrationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromForm] LoginDto loginDto)
        {
            var result = await _Service.Login(loginDto);
            return Ok(result);

        }
    }
}
