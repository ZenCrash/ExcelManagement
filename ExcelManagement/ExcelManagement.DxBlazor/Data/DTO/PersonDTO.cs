using ExcelManagement.DxBlazor.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string? JobTitle { get; set; }

        [StringLength(4000)]
        public string? Bio { get; set; }

        [Url]
        [MaxLength(4000)]
        public string? ProfileImageUrl { get; set; }

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
        public virtual ICollection<RoleDTO> RoleDTOs { get; set; } = new List<RoleDTO>();
        public virtual ICollection<GroupDTO> GroupDTOs { get; set; } = new List<GroupDTO>();
        public virtual ICollection<FileAndFolderDTO> FileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();

        //CreatedBy / UpdatedBy
        public ICollection<PersonDTO> CreatedPersonDTOs { get; set; } = new List<PersonDTO>();
        public ICollection<PersonDTO> UpdatedPersonDTOs { get; set; } = new List<PersonDTO>();

        public ICollection<CompanyDTO> CreatedCompanyDTOs { get; set; } = new List<CompanyDTO>();
        public ICollection<CompanyDTO> UpdatedCompanyDTOs { get; set; } = new List<CompanyDTO>();

        public ICollection<RoleDTO> CreatedRoleDTOs { get; set; } = new List<RoleDTO>();
        public ICollection<RoleDTO> UpdatedRoleDTOs { get; set; } = new List<RoleDTO>();

        public ICollection<GroupDTO> CreatedGroupDTOs { get; set; } = new List<GroupDTO>();
        public ICollection<GroupDTO> UpdatedGroupDTOs { get; set; } = new List<GroupDTO>();

        public ICollection<FileAndFolderDTO> CreatedFileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();
        public ICollection<FileAndFolderDTO> UpdatedFileAndFolderDTOs { get; set; } = new List<FileAndFolderDTO>();
    }
}
