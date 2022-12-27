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
[Route("agent")]
public class AgentController : ControllerBase
{
    private readonly ILogger<AgentController> _logger;
    private readonly IMicroFinDbContext _context;

    public AgentController(ILogger<AgentController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("getall")]
    public async Task<ResponseObject<IEnumerable<Agent>>> GetAll()
    {
        return new ResponseObject<IEnumerable<Agent>>(await _context.Agents.ToListAsync());
    }
    
    [HttpGet("get/{id}")]
    public async Task<ResponseObject<Agent>> Get(int id)
    {
        return new ResponseObject<Agent>(await _context.Agents.FirstOrDefaultAsync(x=>x.Id==id && x.IsActive==true));
    }
    
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(AgentViewRequest model)
    {
        var agent = await _context.Agents.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsActive==true);
        if (agent == null)
        {
            agent = new Agent
            {
                Address = model.Address,
                Mobile = model.Mobile,
                Name = model.Name,
                IsActive = true,
                ModifiedBy = 2,
                ModifiedOn = DateTime.Now,
                Id = 0
            };
            _context.Agents.Add(agent);
        }
        else
        {
            agent.Name = model.Name;
            agent.Mobile = model.Mobile;
            agent.Address = model.Address;
           
        }
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    [HttpPost("delete/{id}")]
    public async Task<ResponseObject<bool>> Delete(int id)
    {
        var agent = await _context.Agents.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        if (agent == null)
        {
            return new ResponseObject<bool>(false,false,"Expense is not found.");
        }
        agent.IsActive = false;
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
}