using ZenTicketsLib.Services;

namespace ZenTicketsLib;

public interface IZenClient
{
    ISearchService Search { get; }
}