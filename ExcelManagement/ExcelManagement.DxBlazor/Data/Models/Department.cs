using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("Departments")]
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [StringLength(256)]
        public string DepartmentName { get; set; }
        [StringLength(10000)]
        public string? Description { get; set; }

        //Fks

        [Required]
        public virtual Company Company { get; set; }

        public ICollection<Person?>? People { get; set; }

    }
}
