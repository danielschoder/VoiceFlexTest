using VoiceFlexTest.BLL;
using VoiceFlexTest.DTO;

namespace VoiceFlexTest;

public static class ApiEndpoints
{
    public static WebApplication MapApiEndpoints(this WebApplication app)
    {
        app.MapPost("/api/testruns", RunTestsAsync);

        return app;
    }

    private static async Task<TestRunReport> RunTestsAsync(ITestRunManager testRunManager)
        => await testRunManager.RunTestsAsync();
}
