using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface IFileAndFolderRepository
    {
        //GetAll
        public List<FileAndFolder> GetAll();

        //Get
        public FileAndFolder Get(Guid id);

        //Create
        public bool Create(FileAndFolder entity);

        //Update
        public bool Update(FileAndFolder entity);

        //Delete
        public bool Delete(Guid id);
    }
}
