# Zendesk Tickets Extractor

A C# library for extracting ticket information and related data from the [Zendesk API](https://developer.zendesk.com/documentation) - Export Search Endpoint.

> **Warning**
> This repository is a work in progress (WIP) and not production-ready! I have requested a sponsored account from the Zendesk team to continue the development of this library.

## Table of Contents

- [Description](#description)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

# Description

This C# library provides a simple and efficient way to extract ticket information and related data from the Zendesk API
Ticket Endpoint. The library handles the authentication, pagination, and parsing of API responses, allowing users to
focus on extracting the required data with ease.

The library use the export search endpoint with all the possible side-loads to retrieve information, you can read more
here: [Zendesk Export Search Results](https://developer.zendesk.com/api-reference/ticketing/ticket-management/search/#export-search-results)

The library is inspired by [justeat/ZendeskApiClient](https://github.com/justeat/ZendeskApiClient), focusing only on ticket data extraction with some general improvements:

 - Serialization/Deserialization is accomplished with System.Text.Json library for improved performance.
 - Side-load ticket information by default and support for the newest extract endpoint 
 - Consolidate the information of a ticket into a single object
 - Query validation 
 - Much features to come..

# Usage

Import the library in your C# project and use the following command in your DI container:

```csharp
services.AddZenLib("<username>", "<password>", "https://<subdomain>.zendesk.com");
```

To use the library you need to inject an IZenClient:

### Example

```csharp
public class App
{
    private readonly IZenClient _zenClient;

    public App(IZenClient zenClient)
    {
        _zenClient = zenClient;
    }

    public async Task Run(string[] args)
    {
        var tickets = await _zenClient.Search.ExportAsync(q => q
            .Add("updated", ">=", "2023-04-11")
            .Add("-subject", ":", "Non Important")
            .Add("-assignee", ":", "839481923")
            .SortBy(SortOption.UpdateAt)
        );
        var json = JsonSerializer.Serialize(tickets, new JsonSerializerOptions { WriteIndented = true });
        await File.WriteAllTextAsync(@"C:\dump.json", json);
    }
}
```

# Contributing
Contributions are welcome! Please be patient, as I will soon create a contribution guideline.<br>
In the meantime, if you want more information, you can contact me directly.

# License
This library is released under the [MIT License](https://mit-license.org/).