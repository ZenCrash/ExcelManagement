using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface IDepartmentRepository
    {
        //GetAll
        public Task<List<Department>> GetAllAsync();
        public Task<List<Department>> GetAllByCompanyIdAsync(Guid id);

        //Get
        public Task<Department> GetAsync(Guid id);

        //Create
        public Task<bool> CreateAsync(Department entity);

        //Update
        public Task<bool> UpdateAsync(Department entity);

        //Delete
        public Task<bool> DeleteAsync(Guid id);
    }
}
