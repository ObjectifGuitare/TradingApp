using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace TradingAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        public readonly IConfiguration Configuration;
        private readonly DataContext context;

        public AuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public AuthController(DataContext context)
        {
            this.context = context;
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            CreatePwdHash(request.Password, out byte[] pwdHash, out byte[] pwdSalt);

            user.Email = request.Email;
            user.PasswordHash = pwdHash;
            user.PasswordSalt = pwdSalt;

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            // SERVER CRASH WHEN PWD IS NULL
            /*
                        var usersFromDb = await context.users.Emails.ToListAsync();*/
            Console.WriteLine(await context.users.ToListAsync());
            if(user.Email != request.Email)
            {
                return BadRequest("User Not Found");
            }
            if (!VerifyPwdHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return BadRequest("L'e mail ou le mot de passe est increct");
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Configuration.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: cred);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);


            return jwt;
        }

        private void CreatePwdHash(string password, out byte[] pwdHash, out byte[] pwdSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                pwdSalt = hmac.Key;
                pwdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }


        private bool VerifyPwdHash(string password, byte[] pwdHash, byte[] pwdSalt)
        {
            if(password == null)
                return false;
            using (var hmac = new HMACSHA512(pwdSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(pwdHash);
            }
        }
    }
}
