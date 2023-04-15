using System.Text;
using Microsoft.Extensions.Options;
using ZenTicketsLib.Extensions;

namespace ZenTicketsLib.Services;

public class BaseHttpService : HttpClient
{
    private readonly IOptions<ZenConfig> _options;
    protected readonly string BaseUri;

    protected BaseHttpService(IOptions<ZenConfig> options)
    {
        BaseUri = options.Value.BaseUri;
        _options = options;
        GenerateAuthKey();
    }

    private void GenerateAuthKey()
    {
        var username = _options.Value.Username;
        var pass = _options.Value.Password;
        var authKey = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}/token:{pass}"));
        DefaultRequestHeaders.Add("Authorization", $"Basic {authKey}");
        DefaultRequestHeaders.Add("Accept", "*/*");
    }

    protected async Task<T> GetAsync<T>(string uri, CancellationToken cancellationToken = default)
    {
        return await GetAsync(uri, cancellationToken)
            .GuardResponse()
            .ReadContentAsAsync<T>();
    }
}