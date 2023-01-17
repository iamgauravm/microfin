using System.Diagnostics;
using System.Security.Claims;
using MicroFIN.Core;
using MicroFIN.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using MicroFIN.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MicroFIN.Controllers;

[Route("Diary")]
public class DiaryController : ControllerBase
{
    private readonly ILogger<DiaryController> _logger;
    private readonly IMicroFinDbContext _context;

    public DiaryController(ILogger<DiaryController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("getall")]
    public async Task<ResponseObject<IEnumerable<Diary>>> GetAll()
    {
        var res = await _context.Dairies
            .Where(x=>x.IsActive==true)
            .Include("Customer")
            // .Include("DiaryInstallments")
            .ToListAsync(); 
        return new ResponseObject<IEnumerable<Diary>>(res);
    }
    
    [HttpGet("getDiarynumber")]
    public async Task<ResponseObject<int>> GetDiaryNumber()
    {
        var lastDiary = await _context.Dairies.OrderByDescending(x=>x.Id).FirstOrDefaultAsync();
        return new ResponseObject<int>(lastDiary?.DiaryNumber??0);
    }
    
    [HttpGet("get/{id}")]
    public async Task<ResponseObject<Diary>> Get(int id)
    {
        return new ResponseObject<Diary>(
            await _context.Dairies
                .Include("Customer")
                .Include("DiaryInstallments")
                .FirstOrDefaultAsync(x=>x.Id==id && x.IsActive==true));
    }
    
    [HttpGet("getbynumber/{number}")]
    public async Task<ResponseObject<DiaryResponseViewModel>> GetByNumber(int number)
    {
        var _res = new DiaryResponseViewModel();
        var Diary = 
            await _context.Dairies
                .Include("Customer")
                .Include("DiaryInstallments")
                .Include("Agent")
                .FirstOrDefaultAsync(x=>x.DiaryNumber==number && x.IsActive==true);

        _res.Id = Diary.Id;
        _res.Installment = Diary.Installment;
        _res.AgentId = Diary.AgentId;
        _res.CustomerId = Diary.CustomerId;
        _res.CustomerMobile = Diary.Customer.Mobile;
        _res.CustomerName = Diary.Customer.AccountName;
        _res.CustomerFatherName = Diary.Customer.FatherName;
        _res.DiaryNumber = Diary.DiaryNumber;
        _res.EndDate = Diary.EndDate;
        _res.HasAgent = Diary.HasAgent;
        _res.IsCompleted = Diary.IsCompleted;
        _res.LoanAmount = Diary.LoanAmount;
        _res.StartDate = Diary.StartDate;
        _res.TotalAmount = Diary.RecoveryAmount;
        _res.TotalBalanceAmount = Diary.TotalBalanceAmount;

        _res.Installments = new List<DiaryInstallmentResponseViewModel>();

        double _lastDue = 0;
        foreach (var item in Diary.DiaryInstallments)
        {
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
            await _context.DiaryReferences
                .Include("Diary")
                .Where(x=>x.DiaryId==Diary.Id)
                .ToListAsync();
        
        var toDairies = 
            await _context.DiaryReferences
                .Include("FromDiary")
                .Where(x=>x.FromDiaryId==Diary.Id)
                .ToListAsync();
        
        foreach (var item in fromDairies)
        {
            _res.FromDairies.Add(new DiaryReffViewModel()
            {
                Invester = "",
                AccountName = item.FromDiary.DiaryNumber.ToString(),
                TransferAmount = item.Amount,
                TransferDate = item.CreatedOn??DateTime.Now
            });
        }
        foreach (var item in fromDairies)
        {
            _res.FromDairies.Add(new DiaryReffViewModel()
            {
                Invester = "",
                AccountName = item.Diary.DiaryNumber.ToString(),
                TransferAmount = item.Amount,
                TransferDate = item.CreatedOn??DateTime.Now
            });
        }
        
        
        
        

        return new ResponseObject<DiaryResponseViewModel>(_res);
    }
    
    
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(Diary model)
    {
        var customer = await _context.Dairies.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsActive == true);
        if (customer == null)
        {
            if (model.AgentId > 1)
            {
                model.HasAgent = true;
                model.Installment = 117;
                model.RecoveryAmount = model.LoanAmount + (model.LoanAmount * 17 / 100);
            }
            else
            {
                model.HasAgent = true;
                model.Installment = 120;
                model.RecoveryAmount = model.LoanAmount + (model.LoanAmount * 20 / 100);
            }

            model.TotalBalanceAmount = model.RecoveryAmount;
            model.IsActive = true;
            model.IsCompleted = false;
            model.CreatedBy = 2;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 2;
            model.ModifiedOn = DateTime.Now;
            //var lst = _context.Dairies.LastOrDefault();
            model.DiaryNumber = 1;// (lst==null?1:(lst.DiaryNumber+1));
            model.StartDate = model.StartDate.AddDays(1);
            model.EndDate = model.StartDate.AddDays(model.Installment);
            _context.Dairies.Add(model);
            await _context.SaveChangesAsync();

            var _InstallmentAmount = model.LoanAmount / 100;
            
            for (int i = 1; i <= model.Installment;i++ )
            {
                _context.DiaryInstallments.Add(new DiaryInstallment 
                    {
                        DiaryId = model.Id, 
                        InstallmentAmount = _InstallmentAmount,
                        BalanceAmount = _InstallmentAmount,
                        InstallmentDate = model.StartDate.AddDays(i),
                        InstallmentNumber = i,
                        PaidAmount = 0,
                        ModifiedBy = 2,
                        ModifiedOn = DateTime.Now,
                        Id = 0
                    });
            }
        }
        else
        {
            // customer.Address = model.Address;
            // // customer.Contacts = model.Contacts;
            // customer.Name = model.Name;
            // customer.FatherName = model.FatherName;
            // customer.Mobile = model.Mobile;
            // customer.Phone = model.Phone;
            // customer.BusinessName = model.BusinessName;
            // customer.IsActive = model.IsActive;
            await _context.SaveChangesAsync();
        }
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    [HttpPost("delete/{id}")]
    public async Task<ResponseObject<bool>> Delete(int id)
    {
        var Diary = await _context.Dairies.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        if (Diary == null)
        {
            return new ResponseObject<bool>(false,false,"Diary is not found.");
        }
        Diary.IsActive = false;
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    
    
 
    [HttpGet("get")]
    public async Task<ResponseObject<IEnumerable<Diary>>> GetAllDropDwon()
    {
        var res = await _context.Dairies
            .Include("Customer")
            // .Include("DiaryInstallments")
            .ToListAsync(); 
        return new ResponseObject<IEnumerable<Diary>>(res);
    }
 
 
    
    // [HttpGet("customers")]
    // public async Task<ResponseObject<IEnumerable<DropDownViewModel>>> GetCustomers()
    // {
    //     var res = await _context.Customers.Where(f=>f.IsActive==true).Select(x=>new DropDownViewModel
    //         {
    //             Id = x.Id,
    //             Name = $"{x.Name} S/o {x.FatherName}"
    //         })
    //         .ToListAsync<DropDownViewModel>(); 
    //     return new ResponseObject<IEnumerable<DropDownViewModel>>(res);
    // }
    // [HttpGet("agents")]
    // public async Task<ResponseObject<IEnumerable<DropDownViewModel>>> GetAgents()
    // {
    //     var res = await _context.Agents.Where(f=>f.IsActive==true).Select(x=>new DropDownViewModel
    //         {
    //             Id = x.Id,
    //             Name = $"{x.Name} [{x.Mobile}]"
    //         })
    //         .ToListAsync<DropDownViewModel>(); 
    //     return new ResponseObject<IEnumerable<DropDownViewModel>>(res);
    // }
    
    [HttpGet("refdiaries")]
    public async Task<ResponseObject<IEnumerable<RefDiaryViewModel>>> GetReferenceDairies()
    {
        var res = await _context.Dairies
            .Where(f=>f.IsActive==true)
            .Select(x=>new RefDiaryViewModel
            {
                Id = x.Id,
                DiaryNumber = $"{x.DiaryNumber}",
                PaidAmount = x.RecoveryAmount - x.TotalBalanceAmount
            })
            .ToListAsync<RefDiaryViewModel>();
        foreach (var item in res)
        {
            item.PaidAmount = item.PaidAmount - GetRefDiaryBalance(item.Id);
        }
        return new ResponseObject<IEnumerable<RefDiaryViewModel>>(res.Where(f=>f.PaidAmount>0));
    }

    private Double GetRefDiaryBalance(int DiaryId)
    {
        return _context.DiaryReferences.Where(x => x.FromDiaryId == DiaryId).Select(f => f.Amount).ToList().Sum(c=>c);
    }
    
    [HttpPost("installment/pay")]
    public async Task<ResponseObject<bool>> Create(DiaryInstallmentPaymentRequest model)
    {
        var DiaryInstallment = await _context.DiaryInstallments.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (DiaryInstallment != null)
        {
            var _amount = model.Amount;
            DiaryInstallment.PaidAmount = DiaryInstallment.PaidAmount+model.Amount;
            var Diary = await _context.Dairies.FirstOrDefaultAsync(x => x.Id == DiaryInstallment.DiaryId);
            Diary.TotalBalanceAmount = Diary.TotalBalanceAmount - _amount;
            var installments = await _context.DiaryInstallments.Where(x => x.DiaryId==DiaryInstallment.DiaryId).ToListAsync();
            foreach (var item in installments)
            {
                if(_amount<=0)
                    break;
                if (item.BalanceAmount > 0)
                {
                    _amount = _amount - item.BalanceAmount;
                    if (_amount > 0)
                    {
                        item.BalanceAmount = 0;
                    }
                    else
                    {
                        item.BalanceAmount = Double.Abs(_amount);
                        _amount = 0;
                    }
                }
            }
            await _context.SaveChangesAsync();
        }
        return new ResponseObject<bool>(true);
    }
    
    
    [HttpGet("getDueDairies")]
    public async Task<ResponseObject<IEnumerable<Diary>>> GetDueDairies()
    {
        var res = await _context.Dairies
            .Where(x=>x.IsActive==true && x.TotalBalanceAmount>0)
            .Include("Customer")
            // .Include("DiaryInstallments")
            .ToListAsync(); 
        return new ResponseObject<IEnumerable<Diary>>(res);
    }
    
    [HttpGet("getClosedDairies")]
    public async Task<ResponseObject<IEnumerable<Diary>>> GetClosedDairies()
    {
        var res = await _context.Dairies
            .Where(x=>x.IsActive==true && x.TotalBalanceAmount==0)
            .Include("Customer")
            // .Include("DiaryInstallments")
            .ToListAsync(); 
        return new ResponseObject<IEnumerable<Diary>>(res);
    }
    
}