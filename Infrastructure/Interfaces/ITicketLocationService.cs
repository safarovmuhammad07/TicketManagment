using DoMain.Models;
using Infrastructure.AppResponse;

namespace Infrastructure.Interfaces;

public interface ITicketLocationService
{
    Responce<List<TicketLocation>> GetTickets();
    Responce<Ticket> GetTicket(int id);
    Responce<bool> AddTicket(Ticket ticket);
    Responce<bool> UpdateTicket(Ticket ticket);
    Responce<bool> DeleteTicket(int id);
}