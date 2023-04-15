namespace ZenTicketsLib.Models.Tickets;

public class CustomFields : List<CustomField>, IReadOnlyCustomFields, ICustomFields
{
    public CustomFields()
    {
    }

    public CustomFields(Dictionary<long, string> fields)
    {
        foreach (var field in fields) this[field.Key] = field.Value;
    }

    public CustomFields(List<CustomField> customFields)
    {
        AddRange(customFields);
    }

    public string? this[long id]
    {
        get => Get(id);
        set => Set(id, value);
    }

    public List<string>? GetValues(long id)
    {
        return this.FirstOrDefault(cf => cf.Id == id)?.Values;
    }

    public void SetValues(long id, List<string> values)
    {
        if (this.All(cf => cf.Id != id))
        {
            Add(new CustomField
            {
                Id = id,
                Values = values
            });
        }
        else
        {
            var customField = this.FirstOrDefault(cf => cf.Id == id);
            if (customField != null)
                customField.Values = values;
        }
    }

    private void Set(long id, string? value)
    {
        if (this.All(cf => cf.Id != id))
        {
            Add(new CustomField
            {
                Id = id,
                Value = value
            });
        }
        else
        {
            var customField = this.FirstOrDefault(cf => cf.Id == id);
            if (customField != null)
                customField.Value = value;
        }
    }

    private string? Get(long id)
    {
        return this.FirstOrDefault(cf => cf.Id == id)?.Value;
    }
}