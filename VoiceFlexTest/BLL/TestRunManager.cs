using VoiceFlexTest.DTO;
using VoiceFlexTest.Services;

namespace VoiceFlexTest.BLL;

interface ITestRunManager
{
    Task<TestRunReport> RunTestsAsync();
}

public class TestRunManager : ITestRunManager
{
    private readonly IVoiceFlexService _voiceFlexService;

    public TestRunManager(IVoiceFlexService voiceFlexService)
        => _voiceFlexService = voiceFlexService;

    public async Task<TestRunReport> RunTestsAsync()
    {
        var testRunReport = new TestRunReport();

        // Scenario 1: Service should be alive
        try
        {
            testRunReport.NumberOfTestsPerformed++;
            testRunReport.VoiceFlexVersion = (await _voiceFlexService.GetServiceAliveAsync()).Version;
            testRunReport.NumberOfTestsPassed++;
        }
        catch { }

        // Scenario 2: /api/accounts/36b5b29e-7984-4274-87bb-91ff2fc72c69/phonenumbers should return this account's 2 phone numbers
        try
        {
            testRunReport.NumberOfTestsPerformed++;
            var result = await _voiceFlexService.GetAccountWithPhoneNumbersAsync(new Guid("36b5b29e-7984-4274-87bb-91ff2fc72c69"));
            if (result.PhoneNumbers.Count == 2
                && result.PhoneNumbers[0].Number.Equals("07479839699")
                && result.PhoneNumbers[1].Number.Equals("07876839785"))
            {
                testRunReport.NumberOfTestsPassed++;
            }
        }
        catch { }

        return testRunReport;
    }
}
