using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface IPersonRepository
    {
        //GetAll
        public Task<List<Person>> GetAllAsync();

        //Get
        public Task<Person> GetAsync(int id);

        //Update
        public Task<bool> UpdateAsync(Person entity);

    }
}
