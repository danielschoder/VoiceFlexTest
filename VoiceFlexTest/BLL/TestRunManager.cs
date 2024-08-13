﻿using VoiceFlexTest.DTO;
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
            var result = await _voiceFlexService.GetServiceAliveAsync();
            testRunReport.NumberOfTestsPassed++;
        }
        catch { }

        // Scenario 2: /api/phonenumbers should return 2 phone numbers
        try
        {
            testRunReport.NumberOfTestsPerformed++;
            var result = await _voiceFlexService.ListPhoneNumbersAsync();
            if (result.Count == 2)
            {
                testRunReport.NumberOfTestsPassed++;
            }
        }
        catch { }

        return testRunReport;
    }
}
