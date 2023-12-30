using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UdemyApp.Business.DTOs.UserDtos;
using UdemyApp.Business.Exceptions.User;
using UdemyApp.Business.Services.Interface;

namespace UdemyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _service;
        public AuthController(IUserService service)
        {
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDto dto)
        {
            try
            {
           await _service.Register(dto);
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
            var result = await _service.Login(loginDto);
            return Ok(result);

        }
    }
}
