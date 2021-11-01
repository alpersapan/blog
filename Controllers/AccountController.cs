using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using blog.Models;
using blog.Data;

namespace blog
{
    public class AccountController : Controller
    {
        private readonly BlogDbContext _context;

        public AccountController(BlogDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
 
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var infos = _context.Users.FirstOrDefault(x=>x.UserMail==user.UserMail && x.UserPw == user.UserPw);
            if (infos != null)
            {
                var claims = new List<Claim>{
                    new Claim(ClaimTypes.Email, user.UserMail)
                };

                var userIdentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("index","admin");
            }
            
            return View();
        }
 
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
 
            return RedirectToAction("login","account");
        }
    }
}