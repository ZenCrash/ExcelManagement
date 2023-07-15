using ExcelManagement.DxBlazor.Data.Models;

namespace ExcelManagement.DxBlazor.Data.DbOption.Interface
{
    public interface ICompanyRepository
    {
        //GetAll
        public List<Company> GetAll();

        //Get
        public Company Get(int id);

        //Create
        public bool Create(Company entity);

        //Update
        public bool Update(Company entity);

        //Delete
        public bool Delete(int id);
    }
}
