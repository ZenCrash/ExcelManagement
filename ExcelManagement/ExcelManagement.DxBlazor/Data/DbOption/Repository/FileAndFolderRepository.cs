using DocumentFormat.OpenXml.InkML;
using ExcelManagement.DxBlazor.Data.DbOption.Interface;
using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExcelManagement.DxBlazor.Data.DbOption.Repository
{
    public class FileAndFolderRepository : IFileAndFolderRepository, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;

        public FileAndFolderRepository(DbContextOptions<ApplicationDbContext> options)
        {
            _dbContext = new ApplicationDbContext(options);
        }

        //GetAll
        public List<FileAndFolder> GetAll()
        {
            return _dbContext.FileAndFolders.ToList();
        }

        //Get
        public FileAndFolder? Get(Guid id)
        {
            return _dbContext.FileAndFolders.Find(id);
        }

        //Create
        public bool Create(FileAndFolder fileAndFolder)
        {
            try
            {
                _dbContext.FileAndFolders.Add(fileAndFolder);
                return true;
                //Save changes must be run after this command to impliment changes
            }
            catch
            {
                return false;
            }
        }

        //Update
        public bool Update(FileAndFolder fileAndFolder)
        {
            try
            {
                _dbContext.Entry(fileAndFolder).State = EntityState.Modified;
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
                FileAndFolder fileAndFolder = _dbContext.FileAndFolders.Find(id);
                _dbContext.FileAndFolders.Remove(fileAndFolder);
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