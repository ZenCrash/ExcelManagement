using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [ForeignKey("Person")]
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
    }
}
