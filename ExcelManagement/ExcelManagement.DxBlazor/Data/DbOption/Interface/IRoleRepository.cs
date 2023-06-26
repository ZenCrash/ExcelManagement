using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface IRoleRepository
    {
        //GetAll
        public List<Role> GetAll();

        //Get
        public Role Get(Guid id);

        //Update
        public bool Update(Role entity);
    }
}
