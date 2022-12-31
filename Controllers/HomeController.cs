using System.Diagnostics;
using System.Security.Claims;
using MicroFIN.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using MicroFIN.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace MicroFIN.Controllers;

[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMicroFinDbContext _context;

    public HomeController(ILogger<HomeController> logger,IMicroFinDbContext context)
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

    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";

        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your contact page.";

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