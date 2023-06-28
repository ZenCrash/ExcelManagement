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
        public Guid? CompanyId { get; set; }
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public Guid? FileAndFolderCreatedById { get; set; }
        public Person FileAndFolderCreatedBy { get; set; }

        public Guid? FileAndFolderUpdatedById { get; set; }
        public Person FileAndFolderUpdatedBy { get; set; }

        //to *
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Group> Groups { get; set; } = new List<Group>(); //NotMapped
        public ICollection<Person> Persons { get; set; } = new List<Person>();
    }
}
