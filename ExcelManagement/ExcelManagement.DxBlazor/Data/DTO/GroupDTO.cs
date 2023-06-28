using ExcelManagement.DxBlazor.Data.Models;
using ExcelManagement.DxBlazor.Data.DTO;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class GroupDTO
    {
        public Guid GroupId { get; set; }

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

        //to 1
        public Guid? CompanyId { get; set; }
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public Guid? GroupCreatedById { get; set; }
        public Person GroupCreatedBy { get; set; }

        public Guid? GroupUpdatedById { get; set; }
        public Person GroupUpdatedBy { get; set; }

        //to *
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();
        public ICollection<Person> Persons { get; set; } = new List<Person>(); //NotMapped
    }
}
