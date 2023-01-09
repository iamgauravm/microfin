using System.Diagnostics;
using System.Security.Claims;
using MicroFIN.Core;
using Microsoft.AspNetCore.Mvc;
using MicroFIN.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

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
    
    [HttpGet("report/getIncomeExpensesReport")]
    public async Task<ResponseObject<IEnumerable<IncomeExpensesReportModel>?>> GetIncomeExpensesReport(int id)
    {
        List<IncomeExpensesReportModel> _lstrepData = new List<IncomeExpensesReportModel>();

        var _dairyColl = await _context.DairyInstallments.Select(x => x.PaidAmount).SumAsync();
        _lstrepData.Add(new IncomeExpensesReportModel{IsIncome= true,Category = "Dairy Collection",Amount = decimal.Parse(_dairyColl.ToString())});

        var _aList  = (from d in _context.Expenses
            select new { d.Category, d.Amount } into x
            group x by new { x.Category } into g
            select new
                {
                Category = g.Key.Category,
                Amount = g.Select(x => x.Amount).Sum()
            });
        foreach (var item in _aList)
        {
            _lstrepData.Add(new IncomeExpensesReportModel{IsIncome= false,Category = item.Category,Amount =decimal.Parse(item.Amount.ToString())});
        }
        
        return new ResponseObject<IEnumerable<IncomeExpensesReportModel>>(_lstrepData);
    }
    
}