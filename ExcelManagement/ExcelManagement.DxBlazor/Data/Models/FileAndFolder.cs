using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraPrinting;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("FilesAndFolders")]
    public class FileAndFolder
    {
        [Key]
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
        [ForeignKey("CompanyId")]
        public Guid? CompanyId { get; set; }
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public Guid? FileAndFolderCreatedById { get; set; }
        public Person FileAndFolderCreatedBy { get; set; }

        public Guid? FileAndFolderUpdatedById { get; set; }
        public Person FileAndFolderUpdatedBy { get; set; }

        //to *
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
        [NotMapped]
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<Person> Persons { get; set; } = new List<Person>();

    }
}
