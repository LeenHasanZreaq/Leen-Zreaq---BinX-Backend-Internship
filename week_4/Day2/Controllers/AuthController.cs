using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly IConfiguration _config;

    public AuthController(
        UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        IConfiguration config)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(
        string email,
        string password)
    {
        var user = new IdentityUser
        {
            UserName = email,
            Email = email
        };

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok("User created successfully");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        string email,
        string password)
    {
        // Find user
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return Unauthorized("Invalid email or password");

        // Check password
        var result = await _signInManager
            .CheckPasswordSignInAsync(
                user,
                password,
                false
            );

        if (!result.Succeeded)
            return Unauthorized("Invalid email or password");

        // Create Claims
        var claims = new[]
        {
            new Claim(
                JwtRegisteredClaimNames.Sub,
                user.Id
            ),

            new Claim(
                ClaimTypes.Email,
                user.Email!
            )
        };

        // Create Secret Key
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _config["Jwt:Key"]!
            )
        );

        // Create JWT
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),

            signingCredentials:
                new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256
                )
        );

        // Convert token to string
        var tokenString =
            new JwtSecurityTokenHandler()
                .WriteToken(token);

        return Ok(new
        {
            token = tokenString
        });
    }
}
