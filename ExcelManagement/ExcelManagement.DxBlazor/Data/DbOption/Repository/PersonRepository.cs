using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class PersonRepository : IPersonRepository
    {
        //GetAll
        public Task<List<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //Get
        public Task<Person> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        //Update
        public Task<bool> UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
