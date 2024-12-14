namespace DoMain.Models;

public class Ticket
{
    public int TicketId { get; set; }
    public string Type { get; set; }
    public string Tittle { get; set; }
    public string TicketPrice { get; set; }
    public DateTime EventDateTime  { get; set; }
}
