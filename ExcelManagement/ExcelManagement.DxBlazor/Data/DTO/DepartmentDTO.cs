using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class DepartmentDTO
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(256)]
        public string DepartmentName { get; set; }
        [StringLength(10000)]
        public string Description { get; set; }

        //Fks

        [Required]
        public virtual CompanyDTO CompanyDTO { get; set; }

        public ICollection<PersonDTO?>? PersonDTOList { get; set; }
    }
}
