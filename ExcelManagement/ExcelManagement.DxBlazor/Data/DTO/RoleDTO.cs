using ExcelManagement.DxBlazor.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class RoleDTO
    {
        public Guid Id { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string? RoleLogoUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        // Relationships

        //to 1
        public Guid? CompanyId { get; set; }
        public virtual CompanyDTO CompanyDTO { get; set; }

        public Guid? CreatedByPersonId { get; set; }
        public PersonDTO? CreatedByPersonDTO { get; set; }

        public Guid? UpdatedByPersonId { get; set; }
        public PersonDTO? UpdatedByPersonDTO { get; set; }
    }
}
