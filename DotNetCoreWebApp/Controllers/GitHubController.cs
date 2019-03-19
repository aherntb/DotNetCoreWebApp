using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreWebApp.HttpClients;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreWebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {
        private readonly IGitHubHttpClient _gitHubHttpClient;

        public GitHubController(IGitHubHttpClient client)
        {
            _gitHubHttpClient = client;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GitHubRepo>>> GetReposAsync()
        {
            var data =  await _gitHubHttpClient.GetReposAsync();
            return Ok(data);

        }

        public class GitHubRepo
        {
            public string Name { get; set; }
        }
    }
}