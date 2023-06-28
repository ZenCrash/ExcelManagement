using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Pages.Account
{
    public class RegisterModel
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
        public Guid MemberCompanyId { get; set; }
        public Guid? MemberGroupId { get; set; }
        [Required]
        public Role? SelectedRole { get; set; }

        public enum Role
        {
            Admin,
            CompanyAdmin,
            DepartmentAdmin,
        }

        public Dictionary<Role, string> Roles { get; } =
            new Dictionary<Role, string>()
            {
                { Role.Admin,"Admin" },
                { Role.CompanyAdmin,"Company Admin" },
                { Role.DepartmentAdmin,"Department Admin" },
            };
    }
}

