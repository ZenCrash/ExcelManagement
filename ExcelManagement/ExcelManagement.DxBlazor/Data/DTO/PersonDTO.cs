//using ExcelManagement.DxBlazor.Data.Models;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

//namespace ExcelManagement.DxBlazor.Data.DTO
//{
//    public class PersonDTO
//    {
//        public Guid Id { get; set; }

//        [Required]
//        [StringLength(256, MinimumLength = 2)]
//        public string FirstName { get; set; }

//        [Required]
//        [StringLength(256, MinimumLength = 2)]
//        public string LastName { get; set; }

//        [StringLength(256)]
//        public string? JobTitle { get; set; }

//        [StringLength(4000)]
//        public string? Bio { get; set; }

//        [Url]
//        [MaxLength(4000)]
//        public string? ProfileImageUrl { get; set; }

//        [Required]
//        public DateTime CreatedDate { get; set; }

//        [Required]
//        public DateTime UpdatedDate { get; set; }

//        //Relations

//        //to 1
//        public Guid? CompanyId { get; set; }
//        public virtual CompanyDTO CompanyDTO { get; set; }

//        public Guid? CreatedByPersonId { get; set; }
//        public PersonDTO? CreatedByPersonDTO { get; set; }

//        public Guid? UpdatedByPersonId { get; set; }
//        public PersonDTO? UpdatedByPersonDTO { get; set; }

//        //to many
//        public ICollection<RoleDTO?>? RoleDTOs { get; set; }
//        public ICollection<GroupDTO?>? GroupDTOs { get; set; }
//        public ICollection<FileAndFolderDTO?>? FilesAndFolderDTOs { get; set; }
//    }
//}
