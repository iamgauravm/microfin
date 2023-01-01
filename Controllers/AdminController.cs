using System.Diagnostics;
using System.Security.Claims;
using MicroFIN.Core;
using Microsoft.AspNetCore.Mvc;
using MicroFIN.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace MicroFIN.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly IMicroFinDbContext _context;

    public AdminController(ILogger<AdminController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }

   
    [Authorize(Roles ="sysadmin,admin, user")]
    public IActionResult Index()
    {
        return View();
    }

    [Authorize(Roles ="sysadmin,admin")]
    public IActionResult Setting()
    {
        return View();

    }

   

    public IActionResult Privacy()
    {
        return View();
    }
    
    public IActionResult Customers()
    {
        return View();
    }
    public IActionResult Agents()
    {
        return View();
    }
    public IActionResult Expences()
    {
        return View();
    }
    
    public IActionResult Dairy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}