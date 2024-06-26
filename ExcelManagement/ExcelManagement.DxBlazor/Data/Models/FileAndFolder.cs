﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using DevExpress.XtraPrinting;

namespace ExcelManagement.DxBlazor.Data.Models
{
    [Table("FilesAndFolders")]
    public class FileAndFolder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        public DateTime UpdatedDate { get; set; }

        [Required]
        [MaxLength(256)]
        public DataFileType DataType { get; set; }

        /* Relationships */

        //to 1
        [Required]
        public Company Company { get; set; }

        //CreatedBy / UpdatedBy
        public Person? CreatedBy { get; set; }
        public Person? UpdatedBy { get; set; }

        //to *
        public virtual ICollection<FileAndFolder> FileAndFolders { get; set; } = new List<FileAndFolder>();
        public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
        public virtual ICollection<Person> Persons { get; set; } = new List<Person>();

        /* DataTypes */
        public enum DataFileType
        {
            Folder,
            Xlsx,
            FileA,
            FileB,
        }
    }
}
