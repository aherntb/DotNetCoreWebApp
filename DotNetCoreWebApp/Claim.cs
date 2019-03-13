using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebApp
{
    public class Claim
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string ClaimNumber { get; set; }
        

    }
}