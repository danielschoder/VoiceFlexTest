using VoiceFlexTest.DTO;

namespace VoiceFlexTest.Services;

public interface IVoiceFlexService
{
    Task<ServiceAlive> GetServiceAliveAsync();
}

public class VoiceFlexService : IVoiceFlexService
{
    private readonly HttpClient _httpClient;

    private string ServiceAliveUrl() => $"/api";

    public VoiceFlexService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<ServiceAlive> GetServiceAliveAsync()
        => await _httpClient.GetFromJsonAsync<ServiceAlive>(ServiceAliveUrl());
}
