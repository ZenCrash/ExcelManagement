using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("FilesAndFolders")]
    public class FileAndFolder
    {
        [Key]
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
        [MaxLength(256)]
        public string DataType { get; set; }

        /* Relationships */

        //to 1
        public Guid CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }

        //to *
        public ICollection<Role> Roles { get; set; } = new List<Role>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();

        [InverseProperty("PersonFileAndFolders")]
        public virtual ICollection<Person> FileAndFolderMembers { get; set; } = new List<Person>();

        [ForeignKey("FileAndFolderCreatedBy")]
        public Guid? FileAndFolderCreatedById { get; set; }
        public Person FileAndFolderCreatedBy { get; set; }

        [ForeignKey("FileAndFolderUpdatedBy")]
        public Guid? FileAndFolderUpdatedById { get; set; }
        public Person FileAndFolderUpdatedBy { get; set; }
    }
}
