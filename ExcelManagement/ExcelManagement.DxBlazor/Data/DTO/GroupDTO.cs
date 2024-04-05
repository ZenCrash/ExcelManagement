using ExcelManagement.DxBlazor.Data.Models;
using ExcelManagement.DxBlazor.Data.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class GroupDTO
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(512)]
        public string GroupName { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string GroupLogoUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        /* Relationships */

        //Self Eefrence

        //to 1
        [Required]
        public CompanyDTO CompanyDTO { get; set; }

        //CreatedBy / UpdatedBy
        public PersonDTO? CreatedByDTO { get; set; }
        public PersonDTO? UpdatedByDTO { get; set; }

        //to *
        public virtual ICollection<GroupDTO> GroupDTOs { get; set; } = new List<GroupDTO>();
        public virtual ICollection<FileAndFolderDTO> FileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();
        public virtual ICollection<PersonDTO> PersonDTOs { get; set; } = new List<PersonDTO>();
    }
}
