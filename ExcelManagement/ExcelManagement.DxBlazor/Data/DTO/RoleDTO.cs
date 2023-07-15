using ExcelManagement.DxBlazor.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class RoleDTO
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string RoleName { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string RoleLogoUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        /* Relationships */

        //to 1

        [Required]
        public CompanyDTO CompanyDTO { get; set; }

        //CreatedBy / UpdatedBy
        public PersonDTO? CreatedByDTO { get; set; }
        public PersonDTO? UpdatedByDTO { get; set; }

        //to *
        public virtual ICollection<PersonDTO> PersonDTOs { get; set; } = new List<PersonDTO>();
        public virtual ICollection<FileAndFolderDTO> FileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();
    }
}
