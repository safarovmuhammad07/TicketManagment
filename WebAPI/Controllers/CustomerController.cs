using DoMain.Models;
using Infrastructure.AppResponse;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CustomerController(ICustomerService customerService):ControllerBase
{
    [HttpGet]
    public Responce<List<Customer>> GetCustomers()
    {
        return customerService.GetCustomers();
    }

    [HttpGet("{id}")]
    public Responce<Customer> GetCustomer(int id)
    {
        return customerService.GetCustomerById(id);
    }

    [HttpPost]
    public Responce<bool> AddCustomer(Customer customer)
    {
        return customerService.AddCustomer(customer);
    }

    [HttpPut("{id}")]
    public Responce<bool> UpdateCustomer(Customer customer)
    {
        return customerService.UpdateCustomer(customer);
    }

    [HttpDelete("{id}")]
    public Responce<bool> DeleteCustomer(int id)
    {
        return customerService.DeleteCustomer(id);
    }
    
    
}