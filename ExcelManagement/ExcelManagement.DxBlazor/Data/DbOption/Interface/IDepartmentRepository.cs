using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface IDepartmentRepository
    {
        //GetAll
        public List<Department> GetAll();
        public List<Department> GetAllByCompanyId(Guid id);

        //Get
        public Department Get(Guid id);

        //Create
        public bool Create(Department entity);

        //Update
        public bool Update(Department entity);

        //Delete
        public bool Delete(Guid id);
    }
}
