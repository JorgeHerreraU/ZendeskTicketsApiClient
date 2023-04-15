using ZenTicketsLib.Models;
using ZenTicketsLib.Models.Tickets;
using ZenTicketsLib.Responses;

namespace ZenTicketsLib.Services;

public interface ISmartTicketMapper
{
    IEnumerable<SmartTicket> MapResponseToSmartTickets((SearchResponse, List<TicketField>) searchResult);
}