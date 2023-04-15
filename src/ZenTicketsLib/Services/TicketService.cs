using Microsoft.Extensions.Options;
using ZenTicketsLib.Extensions;
using ZenTicketsLib.Models.Tickets;
using ZenTicketsLib.Responses;

namespace ZenTicketsLib.Services;

public class TicketService : BaseHttpService, ITicketService
{
    private const string TicketFieldsEndpoint = "ticket_fields";

    public TicketService(IOptions<ZenConfig> options) : base(options)
    {
    }

    public async Task<IEnumerable<TicketField>> GetTicketFields(CancellationToken cancellationToken = default)
    {
        return await GetTicketFieldsResponseAsync(cancellationToken)
            .GetResourceAsync(x => x.TicketFields);
    }

    private async Task<TicketFieldResponse> GetTicketFieldsResponseAsync(CancellationToken cancellationToken = default)
    {
        return await GetAsync<TicketFieldResponse>($"{BaseUri}/{TicketFieldsEndpoint}", cancellationToken);
    }
}