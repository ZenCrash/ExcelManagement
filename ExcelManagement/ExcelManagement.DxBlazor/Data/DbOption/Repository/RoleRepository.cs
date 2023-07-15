using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class RoleRepository : IRoleRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public RoleRepository(DbContextOptions<ApplicationDbContext> options)
        {
            _dbContext = new ApplicationDbContext(options);
        }

        //GetAll
        public List<Role> GetAll()
        {
            return _dbContext.Roles.ToList();
        }

        //Get
        public Role? Get(Guid id)
        {
            return _dbContext.Roles.Find(id);
        }

        //Update
        public bool Update(Role person)
        {
            try
            {
                _dbContext.Entry(person).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
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
