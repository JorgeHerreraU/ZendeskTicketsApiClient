using ZenTicketsLib.Models;

namespace ZenTicketsLib.Builders.Query;

public interface IQuery
{
    IQuery Add(string key, string @operator, string value);
    IQuery SortBy(SortOption sortBy);
    IQuery OrderBy(SortOrder orderBy);
}