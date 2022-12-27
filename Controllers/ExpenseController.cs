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
[Route("expense")]
public class ExpenseController : ControllerBase
{
    private readonly ILogger<ExpenseController> _logger;
    private readonly IMicroFinDbContext _context;

    public ExpenseController(ILogger<ExpenseController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("getall")]
    public async Task<ResponseObject<IEnumerable<Expense>>> GetAll()
    {
        return new ResponseObject<IEnumerable<Expense>>(await _context.Expenses.ToListAsync());
    }
    [HttpGet("get/{id}")]
    public async Task<ResponseObject<Expense>> Get(int id)
    {
        return new ResponseObject<Expense>(await _context.Expenses.FirstOrDefaultAsync(x=>x.Id==id && x.IsActive==true));
    }
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(Expense model)
    {
        var expense = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsActive == true);
        if (expense == null)
        {
            _context.Expenses.Add(model);
        }
        else
        {
            expense.Amount = model.Amount;
            expense.Description = model.Description;
            expense.ExpenseDate = model.ExpenseDate;
            
            // customer.IsActive = model.IsActive;
            await _context.SaveChangesAsync();
        }
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    [HttpPost("delete/{id}")]
    public async Task<ResponseObject<bool>> Delete(int id)
    {
        var customer = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        if (customer == null)
        {
            return new ResponseObject<bool>(false,false,"Expense is not found.");
        }
        customer.IsActive = false;
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
}