using System.Diagnostics;
using System.Security.Claims;
using MicroFIN.Core;
using MicroFIN.Core.Contracts;
using MicroFIN.Core.Services;
using Microsoft.AspNetCore.Mvc;
using MicroFIN.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MicroFIN.Controllers;

[Authorize]
public class AdminController : Controller
{
    private readonly ILogger<AdminController> _logger;
    private readonly IMicroFinDbContext _context;
    private readonly IReportRepo _repoReport;
    

    public AdminController(ILogger<AdminController> logger,IMicroFinDbContext context, IReportRepo repoReport)
    {
        _logger = logger;
        _context = context;
        _repoReport = repoReport;
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
    public IActionResult Customers()
    {
        return View();
    }
    public IActionResult Agents()
    {
        return View();
    }
    public IActionResult Investors()
    {
        return View();
    }
    public IActionResult Expences()
    {
        return View();
    }
    
    public IActionResult Diary()
    {
        return View();
    }
    
    [HttpGet("admin/diarydetail/{number}")]
    public async Task<IActionResult> DiaryDetail(int number)
    {
        var _res = new DiaryResponseViewModel();
        var diary = 
            await _context.Dairies
                .Include("Customer")
                .Include("DiaryInstallments")
                .Include("Agent")
                .FirstOrDefaultAsync(x=>x.DiaryNumber==number && x.IsActive==true);

        _res.Id = diary.Id;
        _res.Installment = diary.Installment;
        _res.AgentId = diary.AgentId;
        _res.CustomerId = diary.CustomerId;
        _res.CustomerMobile = diary.Customer.Mobile;
        _res.CustomerName = diary.Customer.AccountName;
        _res.CustomerFatherName = diary.Customer.FatherName;
        _res.CustomerBusiness = diary.Customer.BusinessName;
        _res.CustomerAddress = diary.Customer.Address;
        _res.CustomerRemarks = diary.Customer.Remarks;
        _res.DiaryNumber = diary.DiaryNumber;
        _res.EndDate = diary.EndDate;
        _res.HasAgent = diary.HasAgent;
        _res.IsCompleted = diary.IsCompleted;
        _res.LoanAmount = diary.LoanAmount;
        _res.StartDate = diary.StartDate;
        _res.TotalAmount = diary.RecoveryAmount;
        _res.TotalBalanceAmount = diary.TotalBalanceAmount;

        _res.Installments = new List<DiaryInstallmentResponseViewModel>();

        double _lastDue = 0;
        double _todayBalance = 0;
        _res.TodayBalance = 0;
        foreach (var item in diary.DiaryInstallments)
        {
            _todayBalance = _todayBalance + item.BalanceAmount;

            if (DateTime.Parse(item.InstallmentDate.ToString("yyyy-MM-dd")) <= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
            {
                _res.TodayBalance = _todayBalance;
            }
            
            _res.Installments.Add(new DiaryInstallmentResponseViewModel
            {
                Id = item.Id,
                BalanceAmount = item.BalanceAmount,
                InstallmentAmount = item.InstallmentAmount,
                InstallmentDate = item.InstallmentDate,
                InstallmentNumber = item.InstallmentNumber,
                PaidAmount = item.PaidAmount
            });
            //_lastDue = (_lastDue + item.BalanceAmount);
        }
        
        
        
        
        var fromDairies = 
            await _context.Transactions
                .Include("Investor")
                .Where(x=>x.DiaryId==diary.AccountId && x.TransactionType==TransactionType.Transfer)
                .ToListAsync();
        
        var toDairies = 
            await _context.Transactions
                .Where(x=>x.FromDiaryId==diary.AccountId)
                .ToListAsync();
        _res.FromDairies = new();
        var accountName = "";
        foreach (var item in fromDairies)
        {
            if (item.FromDiaryId > 0)
            {
                accountName = _context.Accounts.FirstOrDefault(x => x.Id == item.FromDiaryId)?.AccountName;
            }
            _res.FromDairies.Add(new DiaryReffViewModel()
            {
                Invester = "",
                AccountName = (item.InvestorId>0?item.Investor.AccountName:accountName),
                TransferAmount = Math.Abs(item.Amount),
                TransferDate = item.CreatedOn??DateTime.Now
            });
        }

        _res.ToDairies = new();
        foreach (var item in toDairies)
        {
            if (item.FromDiaryId > 0)
            {
                accountName = _context.Accounts.FirstOrDefault(x => x.Id == item.DiaryId)?.AccountName;
            }
            _res.ToDairies.Add(new DiaryReffViewModel()
            {
                Invester = "",
                AccountName = accountName,
                TransferAmount =Math.Abs(item.Amount),
                TransferDate = item.CreatedOn??DateTime.Now
            });
        }        
        return PartialView("_DiaryDetailPartial",_res);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    
    
    [HttpGet("admin/dashboard/counter")]
    public async Task<ResponseObject<DashboardCounterViewModel>> GetCounter()
    {

        var _diariesCount = await _context.Dairies.CountAsync(x => x.IsActive == true);
        var _customersCount = await _context.Accounts.CountAsync(x => x.IsActive == true && x.AccountType==AccountType.Customer && x.IsDefault==false);
        var _totalRevenue = await _context.Dairies.Where(x => x.IsActive == true).SumAsync(f=>f.RecoveryAmount-f.TotalBalanceAmount);
        var _totalExpenses = await _context.Expenses.Where(x => x.IsActive == true).SumAsync(f=>f.Amount);

        var ct = await _repoReport.GetAllLedgerCounter();

        return new ResponseObject<DashboardCounterViewModel>(new DashboardCounterViewModel
        {
            Customers = _customersCount,
            Diaries = _diariesCount,
            RevenueTotal = Convert.ToInt32(_totalRevenue),
            ExpensesTotal = Convert.ToInt32(_totalExpenses),
            TotalCredit = ct.TotalCredit,
            TotalDebit = ct.TotalDebit,
            TotalBalance = ct.TotalBalance
        });
    }
    
}