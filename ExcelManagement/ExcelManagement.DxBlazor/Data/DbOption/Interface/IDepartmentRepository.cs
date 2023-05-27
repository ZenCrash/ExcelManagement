using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface IDepartmentRepository
    {
        //GetAll
        public Task<List<Department>> GetAllAsync();

        //Get
        public Task<Department> GetAsync(int id);

        //Create
        public Task<bool> CreateAsync(Department entity);

        //Update
        public Task<bool> UpdateAsync(Department entity);

        //Delete
        public Task<bool> DeleteAsync(int id);
    }
}
