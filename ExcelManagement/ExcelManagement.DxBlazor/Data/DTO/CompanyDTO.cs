using DevExpress.Utils.Filtering;
using ExcelManagement.DxBlazor.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class CompanyDTO
    {
        public Guid CompanyId { get; set; }

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
        public Guid? CompanyCreatedById { get; set; }
        public Person CompanyCreatedBy { get; set; }

        public Guid? CompanyUpdatedById { get; set; }
        public Person CompanyUpdatedBy { get; set; }

        //to *
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();
        public ICollection<Person> CompanyMembers { get; set; } = new List<Person>();
    }
}
