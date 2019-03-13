using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotNetCoreWebApp.Pages
{
    public class CreateModel : PageModel
    {
        private readonly AppDbContext _appDbContext;
        public CreateModel(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        
        public Claim Claim { get; set; }

        public async Task<ActionResult> OnPostAsync(Claim claim)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _appDbContext.Claims.Add(claim);
            await _appDbContext.SaveChangesAsync();
            return Redirect("Index");
        }
       
    }
}