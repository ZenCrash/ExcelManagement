using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public Person person { get; set; }
    }
}
