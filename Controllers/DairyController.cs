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
[Route("dairy")]
public class DairyController : ControllerBase
{
    private readonly ILogger<DairyController> _logger;
    private readonly IMicroFinDbContext _context;

    public DairyController(ILogger<DairyController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("getall")]
    public async Task<ResponseObject<IEnumerable<Dairy>>> GetAll()
    {
        var res = await _context.Dairies
            .Include("Customer")
            // .Include("DairyInstallments")
            .ToListAsync(); 
        return new ResponseObject<IEnumerable<Dairy>>(res);
    }
    
    [HttpGet("getdairynumber")]
    public async Task<ResponseObject<int>> GetDairyNumber()
    {
        var lastDairy = await _context.Dairies.OrderByDescending(x=>x.Id).FirstOrDefaultAsync();
        return new ResponseObject<int>(lastDairy?.DairyNumber??0);
    }
    
    [HttpGet("get/{id}")]
    public async Task<ResponseObject<Dairy>> Get(int id)
    {
        return new ResponseObject<Dairy>(
            await _context.Dairies
                .Include("Customer")
                .Include("DairyInstallments")
                .FirstOrDefaultAsync(x=>x.Id==id && x.IsActive==true));
    }
    
    [HttpGet("getbynumber/{number}")]
    public async Task<ResponseObject<Dairy>> GetByNumber(int number)
    {
        return new ResponseObject<Dairy>(
            await _context.Dairies
                .Include("Customer")
                .Include("DairyInstallments")
                .FirstOrDefaultAsync(x=>x.DairyNumber==number && x.IsActive==true));
    }
    
    
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(Dairy model)
    {
        var customer = await _context.Dairies.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsActive == true);
        if (customer == null)
        {
            if (model.AgentId > 1)
            {
                model.HasAgent = true;
                model.Installment = 117;
                model.TotalAmount = model.LoanAmount + (model.LoanAmount * 17 / 100);
            }
            else
            {
                model.HasAgent = true;
                model.Installment = 120;
                model.TotalAmount = model.LoanAmount + (model.LoanAmount * 20 / 100);
            }

            model.TotalBalanceAmount = model.TotalAmount;
            model.IsActive = true;
            model.IsCompleted = false;
            model.CreatedBy = 2;
            model.CreatedOn = DateTime.Now;
            model.ModifiedBy = 2;
            model.ModifiedOn = DateTime.Now;
            //var lst = _context.Dairies.LastOrDefault();
            model.DairyNumber = 1;// (lst==null?1:(lst.DairyNumber+1));
            model.StartDate = model.StartDate.AddDays(1);
            model.EndDate = model.StartDate.AddDays(model.Installment);
            _context.Dairies.Add(model);
            await _context.SaveChangesAsync();

            var _InstallmentAmount = model.LoanAmount / 100;
            
            for (int i = 1; i <= model.Installment;i++ )
            {
                _context.DairyInstallments.Add(new DairyInstallment 
                    {
                        DairyId = model.Id, 
                        InstallmentAmount = _InstallmentAmount,
                        BalanceAmount = _InstallmentAmount,
                        InstallmentDate = model.StartDate.AddDays(i),
                        InstallmentNumber = i,
                        IsClosed = false,
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
        var dairy = await _context.Dairies.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        if (dairy == null)
        {
            return new ResponseObject<bool>(false,false,"Dairy is not found.");
        }
        dairy.IsActive = false;
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    
    
    [HttpPost("create")]
    public async Task<ResponseObject<bool>> Create(DairyCreateRequest model)
    {
        var dairy = await _context.Dairies.FirstOrDefaultAsync(x => x.DairyNumber == model.DairyNumber && x.IsActive == true);
        if (dairy == null)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == model.CustomerId && x.IsActive == true);
            if (customer == null)
            {
                customer = new Customer
                {
                    Address = model.CustomerAddress ?? "",
                    Mobile = model.CustomerMobile,
                    Name = model.CustomerName,
                    BusinessName = model.CustomerBusinessName,
                    FatherName = model.CustomerFatherName,
                    CreatedBy = 2,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = 2,
                    ModifiedOn = DateTime.Now,
                    IsActive = true,
                    Phone = model.CustomerMobile
                };
                _context.Customers.Add(customer);
                _context.SaveChangesAsync();
            }
            
            dairy = new Dairy();

            dairy.Installment = model.Installment;
            dairy.AgentId = model.AgentId;
            dairy.DairyNumber = model.DairyNumber;
            dairy.LoanAmount = model.LoanAmount;
            dairy.CustomerId = customer.Id;
            
            if (dairy.AgentId > 1)
            {
                dairy.HasAgent = true;
                dairy.Installment = 117;
                dairy.TotalAmount = dairy.LoanAmount + (dairy.LoanAmount * 17 / 100);
            }
            else
            {
                dairy.HasAgent = true;
                dairy.Installment = 120;
                dairy.TotalAmount = dairy.LoanAmount + (dairy.LoanAmount * 20 / 100);
            }

            dairy.TotalBalanceAmount = dairy.TotalAmount;
            dairy.IsActive = true;
            dairy.IsCompleted = false;
            dairy.CreatedBy = 2;
            dairy.CreatedOn = DateTime.Now;
            dairy.ModifiedBy = 2;
            dairy.ModifiedOn = DateTime.Now;
            var lastDairy = await _context.Dairies.OrderByDescending(x=>x.Id).FirstOrDefaultAsync();
            dairy.DairyNumber = (lastDairy==null?1:(lastDairy.DairyNumber+1));
            dairy.StartDate = model.DairyStartDate.AddDays(1);
            dairy.EndDate = model.DairyStartDate.AddDays(1+model.Installment);
            
            _context.Dairies.Add(dairy);
            await _context.SaveChangesAsync();

            var _InstallmentAmount = dairy.LoanAmount / 100;
            
            for (int i = 1; i <= model.Installment;i++ )
            {
                _context.DairyInstallments.Add(new DairyInstallment 
                    {
                        DairyId = dairy.Id, 
                        InstallmentAmount = _InstallmentAmount,
                        BalanceAmount = _InstallmentAmount,
                        InstallmentDate = dairy.StartDate.AddDays(i),
                        InstallmentNumber = i,
                        IsClosed = false,
                        PaidAmount = 0,
                        ModifiedBy = 2,
                        ModifiedOn = DateTime.Now,
                        Id = 0
                    });
            }

            if (model.RefDairies != null)
            {
                foreach (var item in model.RefDairies)
                {
                    _context.DairyReferences.Add(new DairyReference
                    {
                        Amount = item.LoanAmount,
                        DairyId = dairy.Id,
                        FromDairyId = 1,
                        CreatedBy = 2,
                        CreatedOn = DateTime.Now,
                        ModifiedBy = 2,
                        ModifiedOn = DateTime.Now,

                    });
                }
            }
        }
        
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    [HttpGet("get")]
    public async Task<ResponseObject<IEnumerable<Dairy>>> GetAllDropDwon()
    {
        var res = await _context.Dairies
            .Include("Customer")
            // .Include("DairyInstallments")
            .ToListAsync(); 
        return new ResponseObject<IEnumerable<Dairy>>(res);
    }
 
 
    
    [HttpGet("customers")]
    public async Task<ResponseObject<IEnumerable<DropDownViewModel>>> GetCustomers()
    {
        var res = await _context.Customers.Select(x=>new DropDownViewModel
            {
                Id = x.Id,
                Name = $"{x.Name} S/o {x.FatherName}"
            })
            .ToListAsync<DropDownViewModel>(); 
        return new ResponseObject<IEnumerable<DropDownViewModel>>(res);
    }
    [HttpGet("agents")]
    public async Task<ResponseObject<IEnumerable<DropDownViewModel>>> GetAgents()
    {
        var res = await _context.Agents.Select(x=>new DropDownViewModel
            {
                Id = x.Id,
                Name = $"{x.Name} [{x.Mobile}]"
            })
            .ToListAsync<DropDownViewModel>(); 
        return new ResponseObject<IEnumerable<DropDownViewModel>>(res);
    }
    
    [HttpGet("refdairies")]
    public async Task<ResponseObject<IEnumerable<RefDairyViewModel>>> GetReferenceDairies()
    {
        var res = await _context.Dairies.Select(x=>new RefDairyViewModel
            {
                Id = x.Id,
                DairyNumber = $"{x.DairyNumber}",
                PaidAmount = x.TotalAmount - x.TotalBalanceAmount
            })
            .ToListAsync<RefDairyViewModel>(); 
        return new ResponseObject<IEnumerable<RefDairyViewModel>>(res);
    }
    
    
}