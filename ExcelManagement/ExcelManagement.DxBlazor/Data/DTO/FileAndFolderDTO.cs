using ExcelManagement.DxBlazor.Data.Models;
using ExcelManagement.DxBlazor.Data.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static ExcelManagement.DxBlazor.Data.Models.FileAndFolder;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class FileAndFolderDTO
    {
        public Guid Id { get; set; }

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

        public DataFileType DataType { get; set; }

        /* Relationships */

        //to 1
        [Required]
        public CompanyDTO CompanyDTO { get; set; }

        //CreatedBy / UpdatedBy
        public PersonDTO? CreatedByDTO { get; set; }
        public PersonDTO? UpdatedByDTO { get; set; }

        //to *
        public virtual ICollection<FileAndFolderDTO> FileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();
        public virtual ICollection<RoleDTO> RoleDTOs { get; set; } = new List<RoleDTO>();
        public virtual ICollection<GroupDTO> GroupDTOs { get; set; } = new List<GroupDTO>();
        public virtual ICollection<PersonDTO> PersonDTOs { get; set; } = new List<PersonDTO>();
    }
}
