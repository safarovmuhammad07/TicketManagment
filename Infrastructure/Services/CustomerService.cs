using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.AppResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class CustomerService(DapperContext context):ICustomerService
{
    public Responce<List<Customer>> GetCustomers()
    {
        var sql = "select * from Customers";
        var res=context.GetConnection().Query<Customer>(sql).ToList();
        return new Responce<List<Customer>>(res);
    }

    public Responce<Customer> GetCustomerById(int customerId)
    {
        var sql = "select * from Customers where CustomerId=@CustomerId";
        var res=context.GetConnection().Query<Customer>(sql, new { CustomerId = customerId }).FirstOrDefault();
        return res==null
            ? new Responce<Customer>(HttpStatusCode.NotFound, "Not found")
            :new Responce<Customer>(res);
    }

    public Responce<bool> AddCustomer(Customer customer)
    {
        var sql = "Insert into Customers(FullName,Email,Password) values (@FullName,@Email,@Password)";
        var res=context.GetConnection().Execute(sql,customer);
        return res==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server") 
            : new Responce<bool>(HttpStatusCode.InternalServerError, "Created Successfully"); 
        
    }

    public Responce<bool> UpdateCustomer(Customer customer)
    {
        var sql = "Update Customers set FullName=@FullName, Email=@Email, Password=@Password where CustomerId=@CustomerId";
        var res=context.GetConnection().Execute(sql,customer);
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server")
            : new Responce<bool>(HttpStatusCode.OK, "Updated successfully");
    }

    public Responce<bool> DeleteCustomer(int customerId)
    {
        var sql = "Delete from Customers where CustomerId=@CustomerId";
        var res=context.GetConnection().Execute(sql,customerId);
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server")
            : new Responce<bool>(HttpStatusCode.OK, "Deleted successfully");
    }
}