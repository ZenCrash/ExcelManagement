using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("FilesAndFolders")]
    public class FileAndFolder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 1)]
        [RegularExpression("^[a-zA-Z0-9]*$")]
        public string Name { get; set; }
        [Required]
        [StringLength(2000)]
        public string RelativePath { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }

        [Required]
        [EnumDataType(typeof(DataType))]
        public DataType dataType { get; set; }

        [Required]
        [EnumDataType(typeof(ViewType))]
        public ViewType viewType { get; set; }
        [EnumDataType(typeof(EditType))]
        public virtual EditType editType { get; set; }

        //FK's

        //Company
        [Required]
        public Guid CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        //Department
        public Guid? DepartmentId { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public Department? Department { get; set; }

        //Logic
        public enum DataType
        {
            Folder,
            Excel,
        }

        public enum ViewType
        {
            Public, //Everyone
            Private, //Only the creator
            Limited, //Only serten people
            Company, //Everyone in the company
            CompanyAdmin, //Only CompanyAdmins
            Department, //Only Department members
            DepartmentAdmin, //Only Department Admins
        }

        public enum EditType
        {
            Edit,

            EditPeople,

            EditInfo,

            EditFiles,

            //x2 combo
            EditAndEditPeople,
            EditAndEditInfo,
            EditAndEditFiles,

            EditPeopleAndEditInfo,
            EditPeopleAndEditFiles,

            EditInfoAndEditFiles,

            //x3 combo
            EditAndEditPeopleAndEditInfo,
            EditAndEditPeopleAndEditFiles,
            EditAndEditInfoAndEditFiles,
            EditPeopleAndEditInfoAndEditFiles,

            //x4 combo
            EditAndEditPeopleAndEditInfoAndEditFiles,
        }
    }
}
