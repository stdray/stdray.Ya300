using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace stdray.Ya300.Tests;

public class TestHost
{
    static readonly IHost Host = BuildHost([]);

    public static IServiceScope CreateScope() => Host.Services.CreateScope();

    static IHost BuildHost(string[] args)
    {
        return Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) => { config.AddUserSecrets<TestHost>(); })
            .ConfigureServices((host, services) =>
            {
                var cfg = host.Configuration;
                services.AddHttpClient<Ya300Client>();
                services.Configure<Ya300ClientSettings>(cfg.GetSection(nameof(Ya300ClientSettings)));
                services.AddScoped<Ya300Client>();
                services.AddSingleton<Ya300Parser>();
            })
            .Build();
    }
}