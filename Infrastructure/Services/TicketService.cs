using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.AppResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class TicketService(DapperContext Context):ITicketService
{
    public Responce<List<Ticket>> GetTickets()
    {
        var sql = @"select * from Tickets";
        var res = Context.GetConnection().Query<Ticket>(sql).ToList();
        return new Responce<List<Ticket>>(res);
    }

    public Responce<Ticket> GetTicket(int id)
    {
        var sql = @"select * from Tickets where TicketId = @TicketId";
        var res = Context.GetConnection().Query<Ticket>(sql, new { TicketId = id }).FirstOrDefault();
        return res==null? new Responce<Ticket>(HttpStatusCode.NotFound,"Ticket not found") : new Responce<Ticket>(res);
    }

    public Responce<bool> AddTicket(Ticket ticket)
    {
        var sql =
            "Insert into Tickets(Type, Title,TicketPrice,EventDateTime) values (@Type, @Title,@TicketPrice,@EventDateTime)";
        var res = Context.GetConnection().Execute(sql, ticket);
        return res == 0 
            ?new Responce<bool>(HttpStatusCode.InternalServerError, "Interval Server Eror") 
            :new Responce<bool>(HttpStatusCode.Created, "Ticket added")  ;
    }

    public Responce<bool> UpdateTicket(Ticket ticket)
    {
        var sql= "Update Tickets set Type=@Type,Title=@Title,TicketPrice=@TicketPrice,EventDateTime=@EventDateTime ";
        var res = Context.GetConnection().Execute(sql, ticket);
        return res==0
            ?new Responce<bool>(HttpStatusCode.InternalServerError,"Interval Server Eror")
            :new Responce<bool>(HttpStatusCode.OK, "Ticket updated");
    }

    public Responce<bool> DeleteTicket(int id)
    {
        var sql = "Delete Tickets where TicketId = @TicketId";
        var res = Context.GetConnection().Execute(sql, new { TicketId = id });
        return res==0
            ?new Responce<bool>(HttpStatusCode.InternalServerError,"Interval Server Eror")
            :new Responce<bool>(HttpStatusCode.OK,"Ticket deleted");
    }
}