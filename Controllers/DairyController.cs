using System.Diagnostics;
using System.Security.Claims;
using MicroFIN.Core.Contracts;
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
                .FirstOrDefaultAsync(x=>x.DailyNumber==number && x.IsActive==true));
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
            model.DailyNumber = 1;// (lst==null?1:(lst.DailyNumber+1));
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
}