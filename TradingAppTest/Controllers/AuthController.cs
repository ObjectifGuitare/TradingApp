using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;


namespace TradingAppTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();


        public readonly IConfiguration Configuration;
        private readonly DataContext context;

        public AuthController(IConfiguration configuration, DataContext context)
        {
            Configuration = configuration;
            this.context = context;
        }



        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserDto request)
        {
            var cobaye = new User();
            var profile = new Profile();
            int i = 0;

            var mesUsers = await context.users.Where(x => x.Email == request.Email).ToListAsync();
            mesUsers.ForEach(a => i++);
            if (i > 1)
                return BadRequest("email already exists");
            Regex validateGuidRegex = new Regex("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
            if (!validateGuidRegex.IsMatch(request.Password))
                return BadRequest("Password doesn't match requirements");
            if (!IsMailFormatValid(request.Email))
                return BadRequest("Enter a valid email address !");
            CreatePwdHash(request.Password, out byte[] pwdHash, out byte[] pwdSalt);

            cobaye.Email = request.Email;
            cobaye.PasswordHash = pwdHash;
            cobaye.PasswordSalt = pwdSalt;
            context.users.Add(cobaye);
            await context.SaveChangesAsync();
            

            profile.address = request.Address;
            profile.first_name = request.First_name;
            profile.last_name = request.Last_name;
            var temp = await context.users.ToListAsync();
            var FkId = temp.LastOrDefault().Id;
            profile.userId = FkId;
            Console.WriteLine(FkId);

            context.profiles.Add(profile);
            await context.SaveChangesAsync();
            /* return Ok(await context.users.ToListAsync());*/
            return Ok("registered baby");
        }

        [HttpGet("GetUsers")]

        public async Task<ActionResult<User>> GetUsers()
        {
            return Ok(await context.users.ToListAsync());
        }


        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserDto request)
        {
            /*var usersFromDb = await context.users.Emails.ToListAsync();*/


            if (request.Password == "")
                return BadRequest("remplis ton mot secret fieu");

            int i = 0;
            var SupposedUser = await context.users.Where(x => x.Email == request.Email).ToListAsync();
            
            SupposedUser.ForEach(a => i++);
            if (i < 1)
                return BadRequest("Email or pwd is not THE RIGHT ONE PLEASE");

            /*
            Console.WriteLine("ICI ICI ICI " + SupposedUser.FirstOrDefault().PasswordSalt);*/
            if (!VerifyPwdHash(request.Password, SupposedUser.FirstOrDefault().PasswordHash, SupposedUser.FirstOrDefault().PasswordSalt))
                return BadRequest("Email or pwd is not THE RIGHT ONE PLEASE");
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

        private bool IsMailFormatValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
