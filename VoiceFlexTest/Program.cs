using Microsoft.OpenApi.Models;
using VoiceFlexTest;
using VoiceFlexTest.BLL;
using VoiceFlexTest.Helpers;
using VoiceFlexTest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "VoiceFlexTest API",
        Version = "v1"
    });
});

#region BLL Managers

builder.Services.AddScoped<ITestRunManager, TestRunManager>();

#endregion
#region Client Services

builder.Services.AddConfiguredHttpClient<IVoiceFlexService, VoiceFlexService>(builder.Configuration["SERVICE_URL_VOICEFLEX"]);

#endregion

var app = builder.Build();

app.MapApiEndpoints()
    .UseHttpsRedirection()
    .UseSwagger()
    .UseSwaggerUI();

app.Run();
