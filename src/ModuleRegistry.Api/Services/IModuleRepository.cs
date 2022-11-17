using ModuleRegistry.Api.Models;

namespace ModuleRegistry.Api.Services;

public interface IModuleRepository
{
    IEnumerable<Module> ListModules(); //should this just be type string?
    IEnumerable<string> ListModuleVersions(string moduleName);
    Uri GetModuleVersionUri(string name, string version);
}