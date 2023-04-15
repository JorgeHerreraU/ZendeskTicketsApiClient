using ZenTicketsLib.Services;

namespace ZenTicketsLib;

public class ZenClient : IZenClient
{
    public ZenClient(ISearchService search)
    {
        Search = search;
    }

    public ISearchService Search { get; }
}