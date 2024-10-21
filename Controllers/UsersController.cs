using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public UsersController(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        // POST api/Users/Register
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var userExists = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (userExists != null)
            {
                return BadRequest("A user with this email already exists.");
            }

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST api/Users/Login
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var currentUser = await _dbContext.Users.FirstOrDefaultAsync(u =>
                                        u.Email == user.Email && u.Password == user.Password);

            if (currentUser == null)
            {
                return NotFound("User not found.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new ObjectResult(new
            {
                accessToken = jwt,
                tokenType = "bearer",
                userId = currentUser.Id,
                userName = currentUser.Name
            });
        }

        // POST api/Users/uploadphoto
        [Authorize]
        [HttpPost("uploadphoto")]
        public async Task<IActionResult> UploadUserPhoto(IFormFile image)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (image != null)
            {
                // Generate an unique arquive name for the sent image
                string uniqueFileName = Guid.NewGuid().ToString() + image.FileName;
                string filePath = Path.Combine("wwwroot/userimages", uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(stream);
                }

                // Update the property ImageUrl of the user with the sent image URL
                // Assume the project's 'wwwroot' is the root
                user.ImageUrl = "/userimages/" + uniqueFileName;

                await _dbContext.SaveChangesAsync();
                return Ok("Image sent with success.");
            }

            return BadRequest("No image sent.");
        }

        // GET /api/Users/profileimage
        [Authorize]
        [HttpGet("profileimage")]
        public async Task<IActionResult> UserProfileImage()
        {
            // Verify if the user is authenticated
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            var profileImage = await _dbContext.Users
                .Where(u => u.Email == userEmail)
                .Select(u => new
                {
                    u.ImageUrl
                })
                .SingleOrDefaultAsync();

            return Ok(profileImage);
        }
    }
}
