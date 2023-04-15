using Microsoft.Extensions.Options;
using ZenTicketsLib.Builders.Query;
using ZenTicketsLib.Models;
using ZenTicketsLib.Responses;

namespace ZenTicketsLib.Services;

/// <summary>
///     Service for searching and retrieving tickets and related information.
/// </summary>
public class SearchService : BaseHttpService, ISearchService
{
    private const string SearchEndpoint = "search";
    private readonly ISmartTicketMapper _smartTicketMapper;
    private readonly ITicketService _ticketService;

    public SearchService(IOptions<ZenConfig> options, ITicketService ticketService,
        ISmartTicketMapper smartTicketMapper) : base(options)
    {
        _ticketService = ticketService;
        _smartTicketMapper = smartTicketMapper;
    }

    /// <summary>
    ///     Exports tickets based on the provided query.
    /// </summary>
    /// <param name="configureQuery">Action to configure the query.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A list of SmartTicket objects.</returns>
    public async Task<IEnumerable<SmartTicket>> ExportAsync(Action<IQuery> configureQuery,
        CancellationToken cancellationToken = default)
    {
        var query = new Query();
        configureQuery(query);
        var searchUri = query.BuildUri($"{BaseUri}/{SearchEndpoint}/export");
        return await GetSmartTicketsAsync(searchUri, cancellationToken);
    }

    private async Task<IEnumerable<SmartTicket>> GetSmartTicketsAsync(string searchUri,
        CancellationToken cancellationToken)
    {
        var ticketsTask = GetAsync<SearchResponse>(searchUri, cancellationToken);
        var ticketFieldsTask = _ticketService.GetTicketFields(cancellationToken);

        await Task.WhenAll(ticketsTask, ticketFieldsTask);

        var tickets = ticketsTask.Result;
        var ticketFields = ticketFieldsTask.Result.ToList();

        return _smartTicketMapper.MapResponseToSmartTickets((tickets, ticketFields));
    }
}