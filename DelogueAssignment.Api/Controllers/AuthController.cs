using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace DelogueAssignment.Api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IConfiguration config, ILogger<AuthController> logger)
    {
        _config = config;
        _logger = logger;
    }

    [HttpPost("token")]
    public IActionResult GenerateToken([FromBody] TokenRequest request)
    {
        if (request.Role != "User" && request.Role != "Admin")
        {
            _logger.LogError("Invalid  role!!");

            return Unauthorized();
        }

        var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!);
        var issuer = _config["JwtSettings:Issuer"];

        var claims = new List<Claim> {
            //new Claim(JwtRegisteredClaimNames.Sub, "testuser"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, request.Role),
            new Claim("scope", "read")
        };

        if (request.Role == "Admin") {
            claims.Add(new Claim("scope", "write:admin"));
        }
        else if (request.Role == "User") {
            claims.Add(new Claim("scope", "write:user"));
        }

        var tokenDescriptor = new SecurityTokenDescriptor {
            Issuer = issuer,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        var jwt = tokenHandler.WriteToken(token);

        return Ok(new { token = jwt });
    }
}

public class TokenRequest
{
    public string? Role { get; set; }
}