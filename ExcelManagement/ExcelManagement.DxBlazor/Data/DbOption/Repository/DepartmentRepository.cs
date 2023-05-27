using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public Task<bool> CreateAsync(Department entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
