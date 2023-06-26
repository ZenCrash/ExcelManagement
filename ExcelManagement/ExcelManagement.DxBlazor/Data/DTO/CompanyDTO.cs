using ExcelManagement.DxBlazor.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class CompanyDTO
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(2000)]
        public string CompanyName { get; set; }

        [MaxLength(4000)]
        public string? Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string? CompanyLogoUrl { get; set; }

        //Relationships
        public ICollection<PersonDTO?>? PeopleDTOs { get; set; }
        public ICollection<RoleDTO?>? RoleDTOs { get; set; }
        public ICollection<GroupDTO?>? GroupDTOs { get; set; }
        public ICollection<FileAndFolderDTO?>? FilesAndFolderDTOs { get; set; }

    }
}
