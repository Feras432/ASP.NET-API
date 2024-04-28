using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace ProductAPI.Models
{
    public class TokenService
    {
        private readonly BankContext context;

        public TokenService(BankContext context)
        {
            this.context = context;
        }

        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration, BankContext bankContext)
        {
            _configuration = configuration;
            this.context = bankContext;
        }

        public (bool IsValid, string Token) GenerateToken(string username, string password)
        {
            //if (username != "admin" || password != "admin")
            //{
            //  return (false, "");
            //}
            var userAccount = context.Users.SingleOrDefault(r => r.Username == username);
            if (userAccount == null)
            {
                return (false, "");
            }
            var validPassword = userAccount.VerifyPassword(password);
            if (!validPassword)
            {
                return (false, "");
            }
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(TokenClaimsConstant.Username, username),
                new Claim(TokenClaimsConstant.UserId, "1"),
                new Claim(ClaimTypes.Role, "User")
             };

                var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);
                var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
                return (true, generatedToken);
        }
    }
}
