namespace VoiceFlexTest.Helpers
{
    public static class Extensions
    {
        public static void AddConfiguredHttpClient<TService, TImplementation>(this IServiceCollection services, string urlString)
            where TService : class
            where TImplementation : class, TService
        {
            services.AddHttpClient<TService, TImplementation>(delegate (HttpClient client)
            {
                client.BaseAddress = new Uri(urlString);
            });
        }
    }
}
