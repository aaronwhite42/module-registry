using ModuleRegistry.Api.Models;

namespace ModuleRegistry.Api.Services;

internal class ModuleRepository : IModuleRepository
{
    public IEnumerable<Module> ListModules()
    {
        return Enumerable.Empty<Module>();
    }

    public IEnumerable<string> ListModuleVersions(string moduleName)
    {
        return Enumerable.Empty<string>();
    }

    public Uri GetModuleVersionUri(string name, string version)
    {
        return new Uri("https://someurl.com");
    }
}