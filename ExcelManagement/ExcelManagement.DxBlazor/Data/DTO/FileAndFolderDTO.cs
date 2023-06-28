using ExcelManagement.DxBlazor.Data.Models;
using ExcelManagement.DxBlazor.Data.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class FileAndFolderDTO
    {
        public Guid FilesAndFolderId { get; set; }

        [Required]
        [MaxLength(512)]
        public string ItemName { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Required]
        [MaxLength(4000)]
        public string RelativeFilePath { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        [Required]
        public DateTime UpdatedDate { get; set; }

        [Required]
        [MaxLength(256)]
        public string DataType { get; set; }

        /* Relationships */

        //to 1
        [Required]
        public CompanyDTO CompanyDTO { get; set; }

        //CreatedBy / UpdatedBy
        public PersonDTO FileAndFolderCreatedByDTO { get; set; }

        public PersonDTO FileAndFolderUpdatedByDTO { get; set; }

        //to *
        public ICollection<RoleDTO> RoleDTOs { get; set; } = new List<RoleDTO>();
        public ICollection<GroupDTO> GroupDTOs { get; set; } = new List<GroupDTO>(); //NotMapped
        public ICollection<PersonDTO> PersonDTOs { get; set; } = new List<PersonDTO>();
    }
}
