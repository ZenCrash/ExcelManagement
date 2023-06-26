using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(4000)]
        public string Description { get; set; }

        [Url]
        [MaxLength(4000)]
        public string RoleLogoUrl { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        // Relationships

        //to 1

        [Required]
        public Company Company { get; set; }
        public Person? CreatedByPerson { get; set; }
        public Person? UpdatedByPerson { get; set; }
        public ICollection<Person> RoleMembers { get; set; }
    }
}
