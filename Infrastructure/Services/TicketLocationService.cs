using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.AppResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class TicketLocationService(DapperContext Context):ITicketLocationService
{
    public Responce<List<TicketLocation>> GetTickets()
    {
        var sql = "select * from TicketLocations";
        var res = Context.GetConnection().Query<TicketLocation>(sql).ToList();  
        return new Responce<List<TicketLocation>>(res);
    }

    public Responce<Ticket> GetTicket(int id)
    {
        var sql = "SELECT * FROM TicketLocations WHERE TicketId = @TicketId";
        var res = Context.GetConnection().Query<Ticket>(sql, new { TicketId = id }).FirstOrDefault();
        return res == null
            ? new Responce<Ticket>(HttpStatusCode.NotFound, "Not Found")
            : new Responce<Ticket>(res);
    }

    public Responce<bool> AddTicket(Ticket ticket)
    {
        var sql = "insert into TicketLocations (TicketId, Type, Title,Location) values (@TicketId, @Type, @Title, @Location)";
        var res = Context.GetConnection().Execute(sql, ticket);
        return res == 0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server")
            :new Responce<bool>(HttpStatusCode.Created, "Created");
    }

    public Responce<bool> UpdateTicket(Ticket ticket)
    {
        var sql = "Update TicketLocations set Type=@Type, Title=@Title, Location=@Location where TicketId = @TicketId";
        var res = Context.GetConnection().Execute(sql, ticket);
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server") : new Responce<bool>(HttpStatusCode.OK, "Updated");
    }

    public Responce<bool> DeleteTicket(int id)
    {
        var sql = "delete from TicketLocations where TicketId = @TicketId";
        var res = Context.GetConnection().Execute(sql, new { TicketId = id });
        return res==0 ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server") : new Responce<bool>(HttpStatusCode.OK, "Deleted");

    }
}