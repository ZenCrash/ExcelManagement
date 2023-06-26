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

        //relationships

        //to 1
        [Required]
        public Company Company { get; set; }
        public Person? CreatedByPerson { get; set; }
        public Person? UpdatedByPerson { get; set; }

        //to *
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<Person> FileAndFolderMembers { get; set; } = new List<Person>();
    }
}
