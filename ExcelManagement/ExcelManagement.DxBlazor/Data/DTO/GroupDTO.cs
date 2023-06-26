//using ExcelManagement.DxBlazor.Data.Models;
//using ExcelManagement.DxBlazor.Data.DTO;
//using ExcelManagement.DxBlazor.Data.DTOMapper;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;

//namespace ExcelManagement.DxBlazor.Data.DTO
//{
//    public class GroupDTO
//    {
//        public Guid Id { get; set; }

//        [Required]
//        [MaxLength(512)]
//        public string GroupName { get; set; }

//        [MaxLength(4000)]
//        public string Description { get; set; }

//        [Url]
//        [MaxLength(4000)]
//        public string? GroupLogoUrl { get; set; }

//        [Required]
//        public DateTime CreatedDate { get; set; }

//        // Relationships
//        //to 1
//        public Guid? CompanyId { get; set; }
//        public virtual CompanyDTO CompanyDTO { get; set; }

//        public Guid? CreatedByPersonId { get; set; }
//        public PersonDTO? CreatedByPersonDTO { get; set; }

//        public Guid? UpdatedByPersonId { get; set; }
//        public PersonDTO? UpdatedByPersonDTO { get; set; }

//        //to *
//        public ICollection<FileAndFolderDTO?>? FilesAndFolderDTOs { get; set; }
//        public ICollection<PersonDTO?>? PeopleDTOs { get; set; }
//    }
//}
