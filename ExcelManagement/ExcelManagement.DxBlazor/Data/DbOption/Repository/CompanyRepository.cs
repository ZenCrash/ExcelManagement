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
        public async Task<List<Company>> GetAllAsync()
        {
            return await _dbContext.Companies.ToListAsync();
        }

        //Get
        public async Task<Company?> GetAsync(Guid id)
        {
            return await _dbContext.Companies.FindAsync(id);
        }

        //Create
        public async Task<bool> CreateAsync(Company company)
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
        public async Task<bool> UpdateAsync(Company company)
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
        public async Task<bool> DeleteAsync(Guid id)
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
        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
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
