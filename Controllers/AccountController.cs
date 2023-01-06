using System.Security.Claims;
using MicroFIN.Core;
using MicroFIN.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroFIN.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IMicroFinDbContext _context;

    public AccountController(ILogger<AccountController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string userName, string password)
    {
        if(!string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password))
        {
            return RedirectToAction("Login");
        }
        //Here can be implemented checking logic from the database
        ClaimsIdentity identity = null;
        bool isAuthenticated = false;
        var user = _context.Users.FirstOrDefault(s => s.Username == userName && s.Password==password);
        if (user!=null){
            //Create the identity for the user
            identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("Userid", user.Id.ToString()),
                new Claim("Username", user.Username.ToString())
            }, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var principal = new ClaimsPrincipal(identity);
            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            return RedirectToAction("Index", "Admin");
        }
        return View();
    }
    
    [Authorize]
    [HttpPost]
    public async Task<JsonResult> ChangePassword(string currentPassword, string newPassword)
    {
        if(!string.IsNullOrEmpty(currentPassword) && string.IsNullOrEmpty(newPassword))
        {
            return Json(false);
        }
        int userId = 0;
        var claimsIdentity = User.Identity as ClaimsIdentity;
        
        if (claimsIdentity != null)
        {
            var userIdClaim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == "Userid");
            if (userIdClaim != null) userId = int.Parse(string.IsNullOrWhiteSpace(userIdClaim.Value) ? "0" : userIdClaim.Value);
        }
        var user = _context.Users.FirstOrDefault(s => s.Id == userId && s.Password==currentPassword);
        if (user == null) return Json(false);

        user.Password = newPassword;
        await _context.SaveChangesAsync();
        return Json(true);
    }

    
    public IActionResult Logout()
    {
        var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

}