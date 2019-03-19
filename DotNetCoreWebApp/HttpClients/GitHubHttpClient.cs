using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using DotNetCoreWebApp.Controllers;
using Newtonsoft.Json;

namespace DotNetCoreWebApp.HttpClients
{
    public interface IGitHubHttpClient
    {
        //created to allow implementations be mocked in tests
        Task<IEnumerable<GitHubController.GitHubRepo>> GetReposAsync();
    }

    

    public class GitHubHttpClient: IGitHubHttpClient
    {
        private readonly HttpClient _httpClient;

        public GitHubHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://api.github.com/");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
            httpClient.DefaultRequestHeaders.Add("User-Agent", "my-user-agent");
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GitHubController.GitHubRepo>> GetReposAsync()
        {
            var url = "users/aherntb/repos";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await _httpClient.SendAsync(request);
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<GitHubController.GitHubRepo>>(data);
        }
    }
}
