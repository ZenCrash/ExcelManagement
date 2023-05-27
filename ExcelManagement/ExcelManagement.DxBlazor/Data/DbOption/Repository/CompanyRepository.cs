using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        public Task<bool> CreateAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Company>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Company> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
