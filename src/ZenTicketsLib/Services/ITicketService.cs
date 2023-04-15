using ZenTicketsLib.Models.Tickets;

namespace ZenTicketsLib.Services;

public interface ITicketService
{
    Task<IEnumerable<TicketField>> GetTicketFields(CancellationToken cancellationToken = default);
}