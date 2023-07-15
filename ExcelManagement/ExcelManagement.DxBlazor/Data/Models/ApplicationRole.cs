using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.Models
{
    public class ApplicationRole : IdentityRole
    {
        /* Relationships */

        //to 1
        public Guid? RoleId { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}