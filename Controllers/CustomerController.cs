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
[Route("customer")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IMicroFinDbContext _context;

    public CustomerController(ILogger<CustomerController> logger,IMicroFinDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("getall")]
    public async Task<ResponseObject<IEnumerable<CustomerViewRequest>>> GetAll()
    {
        return new ResponseObject<IEnumerable<CustomerViewRequest>>(await _context.Customers.Select(x=>new CustomerViewRequest
        {
            Address = x.Address,
            Business = x.BusinessName,
            Id = x.Id,
            Mobile = x.Mobile,
            Name = x.Name,
            Remarks = x.Remarks,
            FatherName = x.FatherName,
            Dairies = string.Join(",", _context.Dairies.Where(d => d.CustomerId==x.Id).Select(f=>f.DairyNumber.ToString()).ToList<string>())
        }).ToListAsync<CustomerViewRequest>());
    }
    [HttpGet("get/{id}")]
    public async Task<ResponseObject<CustomerViewRequest>> Get(int id)
    {
        return new ResponseObject<CustomerViewRequest>(await _context.Customers.Select(x=>new CustomerViewRequest
        {
            Address = x.Address,
            Business = x.BusinessName,
            Id = x.Id,
            Mobile = x.Mobile,
            Name = x.Name,
            Remarks = x.Remarks,
            FatherName = x.FatherName,
            Dairies = string.Join(",", _context.Dairies.Where(d => d.CustomerId==x.Id).Select(f=>f.DairyNumber.ToString()).ToList<string>())
        }).FirstOrDefaultAsync(x=>x.Id==id));
    }
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(CustomerViewRequest model)
    {
        try
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsActive == true);
            if (customer == null)
            {
                customer = new Customer
                {
                    Id = 0,
                    Name = model.Name,
                    FatherName = model.FatherName,
                    Mobile = model.Mobile,
                    Phone =  model.Mobile,
                    Address = model.Address,
                    BusinessName = model.Business,
                    Remarks = model.Remarks,
                    CreatedBy = 2,
                    CreatedOn = DateTime.Now,
                    IsActive = true,
                
                    Contacts = new List<Contact>()
                };
                _context.Customers.Add(customer);
            }
            else
            {
                customer.Name = model.Name;
                customer.FatherName = model.FatherName;
                customer.Mobile = model.Mobile;
                customer.Phone = model.Mobile;
                customer.Address = model.Address;
                customer.BusinessName = model.Business;
                customer.Remarks = model.Remarks;
                customer.ModifiedBy = 2;
                customer.ModifiedOn = DateTime.Now;

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
    
    // [HttpPost("contact/{id}/createOrUpdate")]
    // public async Task<ResponseObject<bool>> CreateOrUpdate(int id, Contact model)
    // {
    //     var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == model.Id);
    //     if (contact == null)
    //     {
    //         _context.Contacts.Add(model);
    //     }
    //     else
    //     {
    //         contact.Name = model.Name;
    //         contact.Mobile = model.Mobile;
    //         contact.Address = model.Address;
    //         contact.ContactType = model.ContactType;
    //         contact.ModifiedOn = DateTime.Now;
    //         await _context.SaveChangesAsync();
    //     }
    //     await _context.SaveChangesAsync();
    //     return new ResponseObject<bool>(true);
    // }
    //
    // [HttpPost("contact/delete/{id}")]
    // public async Task<ResponseObject<bool>> CreateOrUpdate(int id)
    // {
    //     var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
    //     if (contact == null)
    //     {
    //         return new ResponseObject<bool>(false,false,"Contact is not found.");
    //     }
    //     _context.Contacts.Remove(contact);
    //     await _context.SaveChangesAsync();
    //     return new ResponseObject<bool>(true);
    // }
    
    [HttpPost("delete/{id}")]
    public async Task<ResponseObject<bool>> Delete(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id && x.IsActive == true);
        if (customer == null)
        {
            return new ResponseObject<bool>(false,false,"Customer is not found.");
        }
        customer.IsActive = false;
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
}