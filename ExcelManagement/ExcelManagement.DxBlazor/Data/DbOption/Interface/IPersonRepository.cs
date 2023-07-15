using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface IPersonRepository
    {
        //GetAll
        public List<Person> GetAll();

        //Get
        public Person Get(Guid id);

        //Update
        public bool Update(Person entity);

    }
}
