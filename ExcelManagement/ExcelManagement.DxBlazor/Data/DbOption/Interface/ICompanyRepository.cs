using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface ICompanyRepository
    {
        //GetAll
        public Task<List<Company>> GetAllAsync();

        //Get
        public Task<Company> GetAsync(Guid id);

        //Create
        public Task<bool> CreateAsync(Company entity);

        //Update
        public Task<bool> UpdateAsync(Company entity);

        //Delete
        public Task<bool> DeleteAsync(Guid id);
    }
}
