using ExcelManagement.DxBlazor.Data.Models;
namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface IGroupRepository
    {
        //GetAll
        public List<Group> GetAll();

        //Get
        public Group Get(int id);

        //Create
        public bool Create(Group entity);

        //Update
        public bool Update(Group entity);

        //Delete
        public bool Delete(int id);
    }
}
