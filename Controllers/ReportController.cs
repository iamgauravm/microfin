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
public class ReportController  : Controller
{
    private readonly ILogger<ReportController> _logger;
    private readonly IMicroFinDbContext _context;

    public ReportController(ILogger<ReportController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    
    [Authorize(Roles ="sysadmin,admin, user")]
    public IActionResult Index()
    {
        return View();
    }
    
}