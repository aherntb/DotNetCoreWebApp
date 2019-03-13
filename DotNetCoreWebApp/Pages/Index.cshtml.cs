using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _appDbContext;

        public IEnumerable<Claim> Claims { get; private set; }

        public IndexModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }       

        public async Task OnGetAsync()
        { 
            Claims = await _appDbContext.Claims.AsNoTracking().ToListAsync();
        }        
    }
}
