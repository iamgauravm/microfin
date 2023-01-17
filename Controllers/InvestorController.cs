using System.Diagnostics;
using System.Security.Claims;
using MicroFIN.Core;
using MicroFIN.Core.Contracts;
using MicroFIN.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using MicroFIN.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace MicroFIN.Controllers;
[Route("investor")]
public class InvestorController : ControllerBase
{
    private readonly ILogger<InvestorController> _logger;
    private readonly IMicroFinDbContext _context;

    public InvestorController(ILogger<InvestorController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("getall")]
    public async Task<ResponseObject<IEnumerable<AgentViewRequest>>> GetAll()
    {
        return new ResponseObject<IEnumerable<AgentViewRequest>>(await _context.Accounts
            .Where(f=>f.AccountType== AccountType.Investor &&f.IsActive==true)
            .Select(x=>new AgentViewRequest
            {
                Address = x.Address??"-",
                Id = x.Id,
                // Installments = 117,
                Mobile = x.Mobile??"",
                Name = x.AccountName,
                // Dairies = string.Join(",", _context.Dairies.Where(d => d.AgentId==x.Id).Select(f=>f.DiaryNumber.ToString()).ToList<string>())
            })
           
            .ToListAsync());
    }
    
    [HttpGet("get/{id}")]
    public async Task<ResponseObject<AgentViewRequest?>> Get(int id)
    {
        return new ResponseObject<AgentViewRequest?>(
            await _context.Accounts
                .Select(x=>new AgentViewRequest
                {
                    Address = x.Address??"-",
                    Id = x.Id,
                    // Installments = 120,
                    Mobile = x.Mobile??"",
                    Name = x.AccountName,
                    // Dairies = string.Join(",", _context.Dairies.Where(d => d.AgentId==x.Id).Select(f=>f.DiaryNumber.ToString()).ToList<string>())
                }).FirstOrDefaultAsync<AgentViewRequest>(x=>x.Id==id));
    }
    
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(AgentViewRequest model)
    {
        var agent = await _context.Accounts.FirstOrDefaultAsync(x =>x.AccountType== AccountType.Investor && x.Id == model.Id && x.IsActive==true);
        if (agent == null)
        {
            agent = new Account
            {
                Address = model.Address,
                Mobile = model.Mobile,
                AccountName = model.Name,
                IsActive = true,
                CreatedBy = 2,
                CreatedOn = DateTime.Now,
                ModifiedBy = 2,
                ModifiedOn = DateTime.Now,
                Id = 0,
                AccountType = AccountType.Investor,
                AccountTypeText = "Agent",
                ParentAccountId = (int)AccountType.Investor
            };
            _context.Accounts.Add(agent);
        }
        else
        {
            agent.AccountName = model.Name;
            agent.Mobile = model.Mobile;
            agent.Address = model.Address;
            agent.ModifiedBy = 2;
            agent.ModifiedOn = DateTime.Now;
        }
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    [HttpPost("delete/{id}")]
    public async Task<ResponseObject<bool>> Delete(int id)
    {
        var agent = await _context.Accounts.FirstOrDefaultAsync(x =>x.AccountType== AccountType.Investor && x.Id == id && x.IsActive == true);
        if (agent == null)
        {
            return new ResponseObject<bool>(false,false,"Agent is not found.");
        }
        agent.IsActive = false;
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
}