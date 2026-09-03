using Authentication_Authorization.Services;
using MicroBasket.Models;
using MicroBasket.Models.DTOs;
using MicroBasket.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroBasket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        private readonly JwtService _jwt;

        public AccountController(IAccountService service,JwtService jwt)
        {
            _service = service;
            _jwt = jwt;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDTO data)
        {
            var response = await _service.LoginAsync(data);
            if(!response.Success)
            {
                return Unauthorized(response.Message);
            }
            var loginResponse=response.Data;

            loginResponse.Token = _jwt.GenerateToken(loginResponse);
            return Ok(loginResponse);
        }
        [HttpPost("register")]
        public async Task<IActionResult> SignIn(RegisterRequestDTO dto)
        {
            dto.Password = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var response=await _service.SignInAsync(dto);
            if(!response.Success)
            {
                return BadRequest(response.Message);
            }
            return Ok(response.Message);
        }
    }
}
