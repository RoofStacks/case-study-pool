using campaign_service.dto;
using campaign_service.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace campaign_service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest model)
        {
            var token = _authService.Authenticate(model.UserName, model.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new { Token = token });
        }
    }
}