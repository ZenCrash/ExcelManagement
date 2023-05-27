using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string JobTitle { get; set; }
        [StringLength(10000)]
        public string Bio { get; set; }
        [Required]
        public CompanyDTO CompanyDTO { get; set; }
        public DepartmentDTO? DepartmentDTO { get; set; }
    }
}
