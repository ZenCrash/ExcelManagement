using DocumentFormat.OpenXml.InkML;
using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class GroupRepository : IGroupRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public GroupRepository(DbContextOptions<ApplicationDbContext> options)
        {
            _dbContext = new ApplicationDbContext(options);
        }

        //GetAll
        public List<Group> GetAll()
        {
            return _dbContext.Groups.ToList();
        }

        //Get
        public Group? Get(Guid id)
        {
            return _dbContext.Groups.Find(id);
        }

        //Create
        public bool Create(Group group)
        {
            try
            {
                _dbContext.Groups.Add(group);
                return true;
                //Save changes must be run after this command to impliment changes
            }
            catch
            {
                return false;
            }
        }

        //Update
        public bool Update(Group group)
        {
            try
            {
                _dbContext.Entry(group).State = EntityState.Modified;
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
                Group group = _dbContext.Groups.Find(id);
                _dbContext.Groups.Remove(group);
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
