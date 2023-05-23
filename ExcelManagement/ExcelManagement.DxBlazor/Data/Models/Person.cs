using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.Models
{
    public class Person
    {
        public Guid id { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2))]
        public string LastName { get; set; }
        [StringLength(256)]
        public string JobTitle { get; set; }

        //FKs - 1 to *

        [Required]
        public string CompanyId { get; set; }
        public string Company company { get; set; }

        public string DepartmentId { get; set; }
        public string Department department { get; set; }
    }
}
