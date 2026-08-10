
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

    // REGISTER
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


    // LOGIN
    [HttpPost("login")]
    public async Task<IActionResult> Login(
        string email,
        string password)
    {
        // 1. Find user
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return Unauthorized("Invalid email or password");
        }


        // 2. Check password using Identity
        var result = await _signInManager.CheckPasswordSignInAsync(
            user,
            password,
            lockoutOnFailure: false
        );

        // 3. Return 401 if credentials are invalid
        if (!result.Succeeded)
        {
            return Unauthorized("Invalid email or password");
        }


        // 4. Create JWT Claims
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


        // 5. Get Secret Key from appsettings.json
        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                _config["Jwt:Key"]!
            )
        );


        // 6. Create JWT
        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],

            claims: claims,

            // Token expires after 15 minutes
            expires: DateTime.UtcNow.AddMinutes(15),

            // Sign the JWT using HMAC SHA256
            signingCredentials: new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            )
        );


        // 7. Convert JWT object to string
        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(token);


        // 8. Return JWT to the client
        return Ok(new
        {
            token = tokenString
        });
    }
}

