using DevExpress.Data.ODataLinq.Helpers;
using DocumentFormat.OpenXml.ExtendedProperties;
using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class DepartmentRepository : IDepartmentRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public DepartmentRepository(DbContextOptions<ApplicationDbContext> options)
        {
            _dbContext = new ApplicationDbContext(options);
        }

        //GetAll
        public async Task<List<Department>> GetAllAsync()
        {
            return await _dbContext.Departments.ToListAsync();
        }
        public async Task<List<Department>> GetAllByCompanyIdAsync(Guid id)
        {
            return await _dbContext.Departments.Where(x => x.Company.Id == id).ToListAsync();
        }

        //Get
        public async Task<Department?> GetAsync(Guid id)
        {
            return await _dbContext.Departments.FindAsync(id);
        }

        //Create
        public async Task<bool> CreateAsync(Department department)
        {
            try
            {
                _dbContext.Departments.Add(department);
                return true;
                //Save changes must be run after this command to impliment changes
            }
            catch
            {
                return false;
            }
        }

        //Update
        public async Task<bool> UpdateAsync(Department department)
        {
            try
            {
                _dbContext.Entry(department).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Delate
        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
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
