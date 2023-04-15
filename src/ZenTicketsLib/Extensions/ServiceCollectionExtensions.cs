using Microsoft.Extensions.DependencyInjection;
using ZenTicketsLib.Services;

namespace ZenTicketsLib.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddZenLib(this IServiceCollection services,
        string username,
        string password,
        string baseUri)
    {
        services.AddScoped<IZenClient, ZenClient>();
        services.AddScoped<ISearchService, SearchService>();
        services.AddScoped<ITicketService, TicketService>();
        services.AddScoped<ISmartTicketMapper, SmartTicketMapper>();

        services.Configure<ZenConfig>(options =>
        {
            options.BaseUri = baseUri;
            options.Username = username;
            options.Password = password;
        });
        return services;
    }
}