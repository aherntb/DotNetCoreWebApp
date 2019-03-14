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

        [BindProperty]
        public Claim Claim { get; set; }

        public async Task<ActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            _appDbContext.Claims.Add(Claim);
            await _appDbContext.SaveChangesAsync();
            return Redirect("Index");
        }
       
    }
}