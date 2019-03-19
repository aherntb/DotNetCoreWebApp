using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetCoreWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GitHubController : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GitHubRepo>>> GetReposAsync()
        {

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept","application/vnd.github.v3+json");
                client.DefaultRequestHeaders.Add("User-Agent","my-user-agent");

                var url = "https://api.github.com/users/aherntb/repos";
                var request = new HttpRequestMessage(HttpMethod.Get, url);

                var response = await client.SendAsync(request);

                var data = await response.Content.ReadAsStringAsync();
                return Ok(JsonConvert.DeserializeObject<IEnumerable<GitHubRepo>>(data));
            }

        }

        public class GitHubRepo
        {
            public string Name { get; set; }
        }
    }
}