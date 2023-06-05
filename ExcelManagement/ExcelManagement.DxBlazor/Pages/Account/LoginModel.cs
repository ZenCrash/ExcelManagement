using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Pages.Account
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
