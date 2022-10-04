using System.Net;
using Microsoft.AspNetCore.Mvc;
using ModuleRegistry.Api.Services;

namespace ModuleRegistry.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;
        
        public ModulesController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }
        
        
        /// <summary>
        /// Get all modules
        /// </summary>
        /// <returns>A collection of modules</returns>
        [HttpGet]
        public IActionResult GetModules()
        {
            try
            {
                return Ok(_moduleRepository.ListModules());
            }
            catch (Exception)
            {
                return Problem();
            }
        }
        
        
        /// <summary>
        /// Get all the versions available for the specified module name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet, Route("{name}/versions")]
        public IActionResult GetModuleVersions(string name)
        {
            try
            {
                return Ok(_moduleRepository.ListModuleVersions(name));
            }
            catch (Exception)
            {
                return Problem();
            }
        }


        /// <summary>
        /// Return the download URL as a header value
        /// </summary>
        /// <param name="name"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpGet, Route("{name}/versions/{version}"), ProducesResponseType((int)HttpStatusCode.NoContent)]
        public IActionResult GetDownloadUrl(string name, string version)
        {
            try
            {
                var uri = _moduleRepository.GetModuleVersionUri(name, version);
                Response.Headers.TryAdd("ModuleUrl", uri.AbsoluteUri);
            }
            catch (Exception)
            {
                return Problem();
            }

            return NoContent();
        } 

    }
}
