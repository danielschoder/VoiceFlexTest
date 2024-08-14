using VoiceFlexTest.DTO;

namespace VoiceFlexTest.Services;

public interface IVoiceFlexService
{
    Task<ServiceAlive> GetServiceAliveAsync();
    Task<Account> GetAccountWithPhoneNumbersAsync(Guid id);
}

public class VoiceFlexService : IVoiceFlexService
{
    private readonly HttpClient _httpClient;

    public VoiceFlexService(HttpClient httpClient) => _httpClient = httpClient;

    public async Task<ServiceAlive> GetServiceAliveAsync()
        => await _httpClient.GetFromJsonAsync<ServiceAlive>("/api");

    public async Task<Account> GetAccountWithPhoneNumbersAsync(Guid id)
        => await _httpClient.GetFromJsonAsync<Account>($"/api/accounts/{id}/phonenumbers");
}
