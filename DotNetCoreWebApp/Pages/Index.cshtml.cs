using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetCoreWebApp.BusinessRules.ClaimBusinessRules;
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

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var claim = await _appDbContext.Claims.FindAsync(id);
            if (claim == null)
            {
                return Page();
            }

            var canDelete = new RuleOne()
                .And(new RuleTwo())
                .IsSatisfiedBy(claim);

            if (canDelete)
            {

                _appDbContext.Remove(claim);
                await _appDbContext.SaveChangesAsync();
                return RedirectToPage();
            }
            return RedirectToPage("Index");

        }
    }
}
