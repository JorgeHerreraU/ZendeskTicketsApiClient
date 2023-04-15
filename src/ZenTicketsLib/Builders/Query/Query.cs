using System.Collections.Specialized;
using System.Web;
using ZenTicketsLib.Models;

namespace ZenTicketsLib.Builders.Query;

public class Query : IQuery
{
    private readonly List<QueryParam> _params = new();
    private readonly NameValueCollection _query = HttpUtility.ParseQueryString(string.Empty);
    private SortOrder _orderBy = SortOrder.Asc;
    private SortOption _sortBy = SortOption.CreatedAt;

    public IQuery Add(string key, string @operator, string value)
    {
        _params.Add(new QueryParam(key, @operator, value));
        return this;
    }

    public IQuery SortBy(SortOption sortBy)
    {
        _sortBy = sortBy;
        return this;
    }

    public IQuery OrderBy(SortOrder orderBy)
    {
        _orderBy = orderBy;
        return this;
    }

    internal string BuildUri(string uri)
    {
        return ValidateParams()
            .SetQueryFields()
            .SetDefaultQueryParams()
            .SortBy()
            .OrderBy()
            .BuildAbsoluteUri(uri);
    }

    private Query ValidateParams()
    {
        new QueryValidator(_params)
            .SetNext(new InvalidOperatorValidator(_params))
            .SetNext(new InvalidKeyValidator(_params))
            .SetNext(new InvalidValueValidator(_params))
            .Handle();
        return this;
    }

    private Query SetQueryFields()
    {
        var fields = _params.Select(param => $"{param.Key}{param.Operator}{param.Value}").ToList();
        _query["query"] = string.Join(' ', fields);
        return this;
    }

    private Query SetDefaultQueryParams()
    {
        var sideloading = new[]
        {
            "brands",
            "custom_statuses",
            "users",
            "groups",
            "organizations",
            "last_audits",
            "metric_sets",
            "dates",
            "sharing_agreements",
            "comment_count",
            "incident_counts",
            "ticket_forms",
            "metric_events",
            "slas"
        };
        _query["page[size]"] = "100";
        _query["include"] = $"tickets({string.Join(", ", sideloading)})";
        _query["filter[type]"] = "ticket";
        return this;
    }

    private Query SortBy()
    {
        _query["sort_by"] = _sortBy switch
        {
            SortOption.CreatedAt => "created_at",
            SortOption.DeletedAt => "deleted_at",
            SortOption.Priority => "priority",
            SortOption.UpdateAt => "updated_at",
            SortOption.TicketType => "ticket_type",
            SortOption.Status => "status",
            _ => throw new ArgumentOutOfRangeException()
        };
        return this;
    }

    private Query OrderBy()
    {
        _query["sort_order"] = _orderBy switch
        {
            SortOrder.Asc => "asc",
            SortOrder.Desc => "desc",
            _ => throw new ArgumentOutOfRangeException(nameof(_orderBy), _orderBy, "Invalid field provided")
        };
        return this;
    }

    private string BuildAbsoluteUri(string uri)
    {
        if (uri.EndsWith("export")) _query.Remove("sort_by");
        return new UriBuilder($"{uri}") { Query = _query.ToString() }.Uri.AbsoluteUri;
    }
}