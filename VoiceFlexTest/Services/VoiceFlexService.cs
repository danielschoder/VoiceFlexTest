using VoiceFlexTest.DTO;

namespace VoiceFlexTest.Services;

public interface IVoiceFlexService
{
    Task<ServiceAlive> GetServiceAliveAsync();
    Task<List<PhoneNumber>> ListPhoneNumbersAsync();
}

public class VoiceFlexService : IVoiceFlexService
{
    private readonly HttpClient _httpClient;

    public VoiceFlexService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<ServiceAlive> GetServiceAliveAsync()
        => await _httpClient.GetFromJsonAsync<ServiceAlive>("/api");

    public async Task<List<PhoneNumber>> ListPhoneNumbersAsync()
        => await _httpClient.GetFromJsonAsync<List<PhoneNumber>>("/api/phonenumbers");
}
