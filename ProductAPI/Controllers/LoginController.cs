using Bank_Branches_Individual_Mini_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenService service;
        private readonly BankContext bankContext;



        public LoginController(TokenService service, BankContext context) 
        {
            this.service = service;
            this.bankContext = context;
        }
        [HttpPost("login")]
        public IActionResult Login(string username, string password)
        {
           var response = this.service.GenerateToken(username, password);
            if (response.IsValid)
            {
                return Ok(new { Token = response.Token});
            } else
            { 
                return BadRequest("Username and/or Password is wrong"); 
            }
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] UserRegistration userRegistration)
        {
            bool isAdmin = false;
            if (bankContext.Users.Count() == 0)
            {
                isAdmin = true;
            }

            var newAccount = UserAccount.Create(userRegistration.Username, userRegistration.Password, isAdmin);

            bankContext.Users.Add(newAccount);
            bankContext.SaveChanges();

            return Ok(new { Message = "User Created" });
        }
    }
}
