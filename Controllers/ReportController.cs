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
public class ReportController : Controller
{
    private readonly ILogger<ReportController> _logger;
    private readonly IMicroFinDbContext _context;

    public ReportController(ILogger<ReportController> logger, IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [Authorize(Roles = "sysadmin,admin, user")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("report/getIncomeExpensesReport")]
    public async Task<ResponseObject<IEnumerable<IncomeExpensesReportModel>?>> GetIncomeExpensesReport(int id)
    {
        List<IncomeExpensesReportModel> _lstrepData = new List<IncomeExpensesReportModel>();

        var _DiaryColl = await _context.DiaryInstallments.Select(x => x.PaidAmount).SumAsync();
        _lstrepData.Add(new IncomeExpensesReportModel { IsIncome = true, Category = "Diary Collection", Amount = decimal.Parse(_DiaryColl.ToString()) });

        var _aList = (from d in _context.Expenses
                      select new { d.Category, d.Amount } into x
                      group x by new { x.Category } into g
                      select new
                      {
                          Category = g.Key.Category,
                          Amount = g.Select(x => x.Amount).Sum()
                      });
        foreach (var item in _aList)
        {
            _lstrepData.Add(new IncomeExpensesReportModel { IsIncome = false, Category = item.Category, Amount = decimal.Parse(item.Amount.ToString()) });
        }

        return new ResponseObject<IEnumerable<IncomeExpensesReportModel>>(_lstrepData);
    }


    [HttpGet("/report/customers")]
    public async Task<IActionResult> GetCustomerWithFilter()
    {
        List<ReportCustomerViewModel> _lstrepData = await  (from c in _context.Accounts
                                                     join d in _context.Dairies on c.Id equals d.CustomerId
                                                     where c.AccountType == Core.Contracts.AccountType.Customer
                                                     orderby c.AccountName
                                                     select new ReportCustomerViewModel
                                                     {
                                                         CustomerId = c.Id,
                                                         CustomerName = c.AccountName,
                                                         FatherName = c.FatherName,
                                                         DiaryId = d.Id,
                                                         DiaryNumber = d.DiaryNumber,
                                                         LoanAmount = d.LoanAmount,
                                                         RecoveryAmount = d.RecoveryAmount,
                                                         PaidAmount = d.TotalPaidAmount,
                                                         BalanceAmount = d.TotalBalanceAmount,
                                                         IsCompleted = d.IsCompleted

                                                     }).ToListAsync();


        return PartialView("_CustomersPartial", _lstrepData);
    }

}