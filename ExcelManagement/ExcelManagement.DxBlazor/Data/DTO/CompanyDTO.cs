using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }
        [StringLength(2000)]
        public string? CompanyName { get; set; }
        [StringLength(10000)]
        public string? Description { get; set; }
        [Url]
        public string? CompanyLogoUrl { get; set; }
        public ICollection<DepartmentDTO?>? DepartmentDTOList { get; set; }
        public ICollection<PersonDTO?>? PersonDTOList { get; set; }

    }
}
