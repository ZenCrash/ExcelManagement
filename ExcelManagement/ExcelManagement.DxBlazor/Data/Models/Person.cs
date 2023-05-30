using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ExcelManagement.DxBlazor.Data;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(256, MinimumLength = 2)]
        public string LastName { get; set; }
        [StringLength(256)]
        public string? JobTitle { get; set; }
        [StringLength(10000)]
        public string? Bio { get; set; }


        //FKs - 1 to *

        [Required]
        public Guid CompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }

        public virtual Department? Department { get; set; }
    }
}
