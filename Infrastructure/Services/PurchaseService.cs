using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.AppResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class PurchaseService(DapperContext context):IPurchaseService
{
    public Responce<List<Purchase>> GetPurchases()
    {
        var sql = @"select * from Purchases";
        var res = context.GetConnection().Query<Purchase>(sql).ToList();
        return new Responce<List<Purchase>>(res);
    }

    public Responce<Purchase> GetPurchasesById(int Id)
    {
        var sql = @"select * from Purchases where Id = @Id";
        var res = context.GetConnection().Query<Purchase>(sql, new { Id = Id }).FirstOrDefault();
        return res==null
            ? new Responce<Purchase>(HttpStatusCode.NotFound, "Not Found") 
            : new Responce<Purchase>(res);
    }

    public Responce<bool> AddPurchase(Purchase purchase)
    {
        var sql = "insert into Purchases(TcketId,CustomerId,PurchaseDateTime,Quantity,TotalPrice) values(@TicketId,@CustomerId,@PurchaseDateTime,@Quantity,@TotalPrice)";
        var res = context.GetConnection().Execute(sql, purchase);
        return res == 0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Internal Server Error")
            : new Responce<bool>(HttpStatusCode.Created, "Created");
    }

    public Responce<bool> UpdatePurchase(Purchase purchase)
    {
        var sql = "update Purchases set TcketId=@TicketId,CustomerId=@CustomerId,Quantity=@Quantity,TotalPrice=@TotalPrice";
        var res = context.GetConnection().Execute(sql, purchase);
        return res==0
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server")
            : new Responce<bool>(HttpStatusCode.OK, "Updated");
    }

    public Responce<bool> DeletePurchase(Purchase purchase)
    {
        var sql =@"delete from Purchases where Id = @Id";
        var res = context.GetConnection().Execute(sql, purchase);
        return res==0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server")
            : new Responce<bool>(HttpStatusCode.OK, "Deleted");
    }
}