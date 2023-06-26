using ExcelManagement.DxBlazor.Data.Models;
using ExcelManagement.DxBlazor.Data.DTO;
using ExcelManagement.DxBlazor.Data.DTOMapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.DTO
{
    public class FileAndFolderDTO
    {
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
        public Guid? CompanyId { get; set; }
        public virtual CompanyDTO CompanyDTO { get; set; }

        public Guid? CreatedByPersonId { get; set; }
        public PersonDTO? CreatedByPersonDTO { get; set; }

        public Guid? UpdatedByPersonId { get; set; }
        public PersonDTO? UpdatedByPersonDTO { get; set; }

        //to *
        public ICollection<GroupDTO?>? GroupDTOs { get; set; }
        public ICollection<PersonDTO?>? PeopleDTOs { get; set; }
    }
}
