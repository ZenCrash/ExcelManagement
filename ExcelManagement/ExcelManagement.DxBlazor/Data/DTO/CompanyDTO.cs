using DevExpress.Utils.Filtering;
using ExcelManagement.DxBlazor.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class CompanyDTO
    {
        public int CompanyId { get; set; }

        [Required]
        [StringLength(2000)]
        public string CompanyName { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string CompanyLogoUrl { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public DateTime UpdatedDate { get; set; }

        /* Relationships */

        //CreatedBy / UpdatedBy
        public PersonDTO CompanyCreatedByDTO { get; set; }

        public PersonDTO CompanyUpdatedByDTO { get; set; }

        //to *
        public ICollection<RoleDTO> RoleDTOs { get; set; } = new List<RoleDTO>();
        public ICollection<GroupDTO> GroupDTOs { get; set; } = new List<GroupDTO>();
        public ICollection<FileAndFolderDTO> FileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();
        public ICollection<PersonDTO> CompanyMemberDTOs { get; set; } = new List<PersonDTO>();
    }
}
