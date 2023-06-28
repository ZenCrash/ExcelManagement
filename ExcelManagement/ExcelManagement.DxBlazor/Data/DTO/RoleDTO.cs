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
        public Guid? CompanyId { get; set; }
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public Guid? RoleCreatedById { get; set; }
        public Person RoleCreatedBy { get; set; }

        public Guid? RoleUpdatedById { get; set; }
        public Person RoleUpdatedBy { get; set; }

        //to *
        public ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>(); //NotMapped
        public ICollection<Person> Persons { get; set; } = new List<Person>(); //NotMapped
    }
}
