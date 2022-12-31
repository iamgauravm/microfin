using MicroFIN.Core.Contracts;
using MicroFIN.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using MicroFIN.Models;
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
    public async Task<ResponseObject<IEnumerable<ExpenseViewModel>>> GetAll()
    {
        return new ResponseObject<IEnumerable<ExpenseViewModel>>(await _context.Expenses
            .Where(f=>f.IsActive==true)
            .Select(x=>new ExpenseViewModel
                {
                    Amount = x.Amount,
                    Description = x.Description,
                    Id = x.Id,
                    ExpenseDate = x.ExpenseDate
                }).ToListAsync());
    }
    [HttpGet("get/{id}")]
    public async Task<ResponseObject<ExpenseViewModel?>> Get(int id)
    {
        return new ResponseObject<ExpenseViewModel?>(await _context.Expenses.Select(x=>new ExpenseViewModel
        {
            Amount = x.Amount,
            Description = x.Description,
            Id = x.Id,
            ExpenseDate = x.ExpenseDate
        }).FirstOrDefaultAsync(x=>x.Id==id));
    }
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(ExpenseViewModel model)
    {
        try
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsActive == true);
            if (expense == null)
            {
                expense = new Expense
                {
                    Amount = model.Amount,
                    Description = model.Description,
                    Id = 0,
                    CreatedBy = 2,
                    CreatedOn = DateTime.Now,
                    ExpenseDate = model.ExpenseDate,
                    IsActive = true,
                    ModifiedBy = 2,
                    ModifiedOn = DateTime.Now
                };
                _context.Expenses.Add(expense);
            }
            else
            {
                expense.Amount = model.Amount;
                expense.Description = model.Description;
                expense.ExpenseDate = model.ExpenseDate;
                expense.ModifiedBy = 2;
                expense.ModifiedOn = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new ResponseObject<bool>(false);
        }
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