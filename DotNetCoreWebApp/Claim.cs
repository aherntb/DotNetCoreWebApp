using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebApp
{
    public class Claim
    {
        
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        [DisplayName("Claim Number")]
        public string ClaimNumber { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("First Name")]
        public string PatientFirstName { get; set; }

        [Required]
        [StringLength(25)]
        [DisplayName("Last Name")]
        public string PatientLastName  { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime  PatientBirthDate { get; set; }

    }
}