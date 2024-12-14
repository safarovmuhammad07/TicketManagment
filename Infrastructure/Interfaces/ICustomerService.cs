using DoMain.Models;
using Infrastructure.AppResponse;

namespace Infrastructure.Interfaces;

public interface ICustomerService
{
    Responce<List<Customer>> GetCustomers();
    Responce<Customer> GetCustomerById(int customerId);
    Responce<bool> AddCustomer(Customer customer);
    Responce<bool> UpdateCustomer(Customer customer);
    Responce<bool> DeleteCustomer(int customerId);
}