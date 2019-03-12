using System;
using System.ComponentModel.DataAnnotations;

namespace DotNetCoreWebApp
{
    public class Customer
    {
       public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(25)]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}