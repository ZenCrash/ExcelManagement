using DocumentFormat.OpenXml.InkML;
using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class PersonRepository : IPersonRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public PersonRepository(DbContextOptions<ApplicationDbContext> options)
        {
            _dbContext = new ApplicationDbContext(options);
        }

        //GetAll
        public List<Person> GetAll()
        {
            return _dbContext.Persons.ToList();
        }

        //Get
        public Person? Get(Guid id)
        {
            return _dbContext.Persons.Find(id);
        }

        //Update
        public bool Update(Person person)
        {
            try
            {
                _dbContext.Entry(person).State = EntityState.Modified;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }


        /* Logic */

        //Save
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        //Dispose
        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
