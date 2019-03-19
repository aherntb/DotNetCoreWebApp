using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreWebApp.Controllers;

namespace DotNetCoreWebApp.HttpClients
{
    public interface IGitHubHttpClient
    {
        //created to allow implementations be mocked in tests
        Task<IEnumerable<GitHubController.GitHubRepo>> GetReposAsync();
    }
}