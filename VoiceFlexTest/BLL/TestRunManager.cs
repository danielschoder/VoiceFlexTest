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

    public TestRunManager(IVoiceFlexService voiceFlexService) => _voiceFlexService = voiceFlexService;

    public async Task<TestRunReport> RunTestsAsync()
    {
        var testRunReport = new TestRunReport();

        // Scenario 1: Service should be alive
        testRunReport.NumberOfTestsPerformed++;
        try
        {
            var result = await _voiceFlexService.GetServiceAliveAsync();
            testRunReport.NumberOfTestsPassed++;
        }
        catch
        {
        }

        return testRunReport;
    }
}
