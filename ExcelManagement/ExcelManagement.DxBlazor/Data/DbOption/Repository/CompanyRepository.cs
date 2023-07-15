using DocumentFormat.OpenXml.InkML;
using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class CompanyRepository : ICompanyRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(DbContextOptions<ApplicationDbContext> options)
        {
            _dbContext = new ApplicationDbContext(options);
        }

        //GetAll
        public List<Company> GetAll()
        {
            return _dbContext.Companies.ToList();
        }

        //Get
        public Company? Get(Guid id)
        {
            return _dbContext.Companies.Find(id);
        }

        //Create
        public bool Create(Company company)
        {
            try
            {
                _dbContext.Companies.Add(company);
                return true;
                //Save changes must be run after this command to impliment changes
            }
            catch
            {
                return false;
            }
        }

        //Update
        public bool Update(Company company)
        {
            try
            {
                _dbContext.Entry(company).State = EntityState.Modified;
                return true;
                //Save changes must be run after this command to impliment changes
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Delete
        public bool Delete(Guid id)
        {
            try
            {
                Company company = _dbContext.Companies.Find(id);
                _dbContext.Companies.Remove(company);
                return true;
                //Save changes must be run after this command to impliment changes
            }
            catch
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
