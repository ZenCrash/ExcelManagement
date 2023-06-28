using ExcelManagement.DxBlazor.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class RoleDTO
    {
        public Guid RoleId { get; set; }

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
        public PersonDTO RoleCreatedByDTO { get; set; }
        public PersonDTO RoleUpdatedByDTO { get; set; }

        //to *
        public ICollection<FileAndFolderDTO> FileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>(); //NotMapped
        public ICollection<PersonDTO> PersonDTOs { get; set; } = new List<PersonDTO>(); //NotMapped
    }
}
