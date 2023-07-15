using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

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
        public Person CreatedBy { get; set; }
        public Person UpdatedBy { get; set; }

        //to *
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();
        public virtual ICollection<Person> People { get; set; } = new List<Person>();
    }
}
