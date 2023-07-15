using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        /* Relationships */

        //to 1
        public Guid? PersonId { get; set; }
        [Required]
        public Person Person { get; set; }
    }
}
