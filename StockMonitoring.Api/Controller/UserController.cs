using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StockMonitoring.Application.Common.Interface;
using StockMonitoring.Domain.Models;

namespace StockMonitoring.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController(IUserRepository userRepository) :ControllerBase
    {
        [HttpPost("/register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var result = await userRepository.RegisterAsync(new Application.DTOs.UserRegisterDto
            {
                Username = user.Username,
                Password = user.PasswordHash
            });
            return Ok(result);
        }
        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromBody] Application.DTOs.UserLoginDto dto)
        {
            var token = await userRepository.LoginAsync(dto);
            return Ok(new { Token = token });
        }
    }
     
}
