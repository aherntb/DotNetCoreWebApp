using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebApp.Pages
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _appDbContext;

        public EditModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [BindProperty]
        public Claim Claim { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Claim = await _appDbContext.Claims.FindAsync(id);
            if(Claim == null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _appDbContext.Attach(Claim).State = EntityState.Modified;
            try
            {
                await _appDbContext.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException e)
            {
                throw new Exception($"Claimm {Claim.Id} not found",e);
            }

            
            return RedirectToPage("Index");

        }

        
    }
}