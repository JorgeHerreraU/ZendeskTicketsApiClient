using System.Text.RegularExpressions;

namespace ZenTicketsLib.Builders.Query;

public class QueryValidator
{
    protected readonly List<QueryParam> QueryParams;
    private QueryValidator? _next;

    public QueryValidator(List<QueryParam> queryParams)
    {
        QueryParams = queryParams;
    }

    public QueryValidator SetNext(QueryValidator next)
    {
        if (_next is not null) _next.SetNext(next);
        else _next = next;
        return this;
    }

    public virtual void Handle()
    {
        _next?.Handle();
    }

    protected static void ThrowIfInvalid(string? field)
    {
        if (field != null)
            throw new ArgumentOutOfRangeException(nameof(field), $"{field} is not allowed");
    }

    protected QueryParam? FindNotContains(HashSet<string> allowed, Func<QueryParam, string> key)
    {
        return QueryParams.FirstOrDefault(p => !allowed.Any(s => key(p).Contains(s)));
    }
}

public class InvalidOperatorValidator : QueryValidator
{
    private readonly HashSet<string> _allowedOperators = new() { ":", "<", ">", ">=", "<=" };

    public InvalidOperatorValidator(List<QueryParam> queryParams) : base(queryParams)
    {
    }

    public override void Handle()
    {
        ThrowIfInvalid(FindNotContains(_allowedOperators, p => p.Operator)?.Operator);
        base.Handle();
    }
}

public class InvalidKeyValidator : QueryValidator
{
    private readonly HashSet<string> _allowedKeys = new()
    {
        "status",
        "priority",
        "created",
        "updated",
        "solved",
        "due_date",
        "assignee",
        "submitter",
        "subject",
        "description",
        "custom_status_id",
        "ticket_type",
        "group",
        "organization",
        "tags",
        "via",
        "commenter",
        "cc",
        "fieldvalue",
        "brand",
        "has_attachment",
        "form",
        "recipient",
        "subject"
    };

    public InvalidKeyValidator(List<QueryParam> queryParams) : base(queryParams)
    {
    }

    public override void Handle()
    {
        ThrowIfInvalid(FindNotContains(_allowedKeys, p => p.Key)?.Key);
        base.Handle();
    }
}

public partial class InvalidValueValidator : QueryValidator
{
    public InvalidValueValidator(List<QueryParam> queryParams) : base(queryParams)
    {
    }

    [GeneratedRegex("^[a-zA-Z0-9_-]+$")]
    private static partial Regex Pattern();

    public override void Handle()
    {
        var invalidValue = QueryParams.FirstOrDefault(p => !Pattern().IsMatch(p.Value));
        ThrowIfInvalid(invalidValue?.Value);
        base.Handle();
    }
}