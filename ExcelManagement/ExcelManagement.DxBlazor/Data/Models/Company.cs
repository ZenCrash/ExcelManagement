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
        [StringLength(10000)]
        public string? Description { get; set; }
        [Url]
        public string? CompanyLogoUrl { get; set; }

        //FKs 
        public ICollection<Department?>? Departments { get; set; }
        public ICollection<Person?>? People { get; set; }
        public ICollection<FileAndFolder?>? fileAndFolders { get; set; }

    }
}
