using Microsoft.Extensions.DependencyInjection;

namespace stdray.Ya300.Tests;

public class BaseTests : IDisposable
{
    IServiceScope Scope { get; }  = TestHost.CreateScope();
    
    protected T Resolve<T>() => Scope.ServiceProvider.GetRequiredService<T>();

    protected string ReadText(string path)
    {
        var testNamespace = GetType().Namespace!;
        var baseNamespace = typeof(BaseTests).Namespace!;
        var slug = testNamespace.StartsWith(baseNamespace) 
            ? testNamespace[baseNamespace.Length..].Trim('.')
            : string.Empty;
        var dir = AppDomain.CurrentDomain.BaseDirectory;
        return File.ReadAllText(Path.Combine(dir, slug, path));
    }
    
    public void Dispose()
    {
        Scope.Dispose();
        GC.SuppressFinalize(this);
    }
}