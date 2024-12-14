using DoMain.Models;
using Infrastructure.AppResponse;

namespace Infrastructure.Interfaces;

public interface ITicketService
{
    Responce<List<Ticket>> GetTickets();
    Responce<Ticket> GetTicket(int id);
    Responce<bool> AddTicket(Ticket ticket);
    Responce<bool> UpdateTicket(Ticket ticket);
    Responce<bool> DeleteTicket(int id);
}