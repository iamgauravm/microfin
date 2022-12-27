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
    public async Task<ResponseObject<IEnumerable<Customer>>> GetAll()
    {
        return new ResponseObject<IEnumerable<Customer>>(await _context.Customers.ToListAsync());
    }
    [HttpGet("get/{id}")]
    public async Task<ResponseObject<Customer>> Get(int id)
    {
        return new ResponseObject<Customer>(await _context.Customers.FirstOrDefaultAsync(x=>x.Id==id && x.IsActive==true));
    }
    [HttpPost("createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(CustomerViewRequest model)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == model.Id && x.IsActive == true);
        if (customer == null)
        {
            customer = new Customer
            {
                Address = "",
                Id = 0,
                Mobile = model.Mobile,
                Name = model.Name,
                Phone =  model.Mobile,
                BusinessName = "",
                CreatedBy = 2,
                CreatedOn = DateTime.Now,
                FatherName = "",
                IsActive = true,
                ModifiedBy = 2,
                ModifiedOn = DateTime.Now,
                Contacts = new List<Contact>()
            };
            _context.Customers.Add(customer);
        }
        else
        {
            customer.Address = model.Address;
            // customer.Contacts = model.Contacts;
            customer.Name = model.Name;
            customer.FatherName = "";
            customer.Mobile = model.Mobile;
            customer.Phone = "";
            customer.BusinessName = "";
            // customer.IsActive = model.IsActive;
            await _context.SaveChangesAsync();
        }
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
    [HttpPost("contact/{id}/createOrUpdate")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(int id, Contact model)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (contact == null)
        {
            _context.Contacts.Add(model);
        }
        else
        {
            contact.Name = model.Name;
            contact.Mobile = model.Mobile;
            contact.Address = model.Address;
            contact.ContactType = model.ContactType;
            contact.ModifiedOn = DateTime.Now;
            await _context.SaveChangesAsync();
        }
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
   
    [HttpPost("contact/delete/{id}")]
    public async Task<ResponseObject<bool>> CreateOrUpdate(int id)
    {
        var contact = await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        if (contact == null)
        {
            return new ResponseObject<bool>(false,false,"Contact is not found.");
        }
        _context.Contacts.Remove(contact);
        await _context.SaveChangesAsync();
        return new ResponseObject<bool>(true);
    }
    
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