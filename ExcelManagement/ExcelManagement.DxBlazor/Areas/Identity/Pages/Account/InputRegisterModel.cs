using System.ComponentModel.DataAnnotations;
using ExcelManagement.DxBlazor.Data;
using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Areas.Identity.Pages.Account
{
    public class InputRegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        public CompanyDTO CompanyDTO { get; set; }
        public DepartmentDTO? DepartmentDTO { get; set; }

    }
}
