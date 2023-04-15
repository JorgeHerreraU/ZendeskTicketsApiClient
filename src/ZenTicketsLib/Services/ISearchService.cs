using ZenTicketsLib.Builders.Query;
using ZenTicketsLib.Models;

namespace ZenTicketsLib.Services;

public interface ISearchService
{
    Task<IEnumerable<SmartTicket>> ExportAsync(Action<IQuery> configureQuery,
        CancellationToken cancellationToken = default);
}