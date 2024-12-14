using System.Diagnostics.CodeAnalysis;
using DoMain.Models;
using Infrastructure.AppResponse;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class TicketController(ITicketService ticketService):ControllerBase
{
    [HttpGet]
    public Responce<List<Ticket>> Get()
    {
        return ticketService.GetTickets();
    }

    [HttpGet("{id}")]
    public Responce<Ticket> Get(int id)
    {
        return ticketService.GetTicket(id);
    }

    [HttpPost]
    public Responce<bool> Post( Ticket ticket)
    {
        return ticketService.AddTicket(ticket);
    }

    [HttpPut]
    public Responce<bool> Put(Ticket ticket)
    {
        return ticketService.UpdateTicket(ticket);
    }

    [HttpDelete]
    public Responce<bool> Delete(int id)
    {
        return ticketService.DeleteTicket(id);
    }
}