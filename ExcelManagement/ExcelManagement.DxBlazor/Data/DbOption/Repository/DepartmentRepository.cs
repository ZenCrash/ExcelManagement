﻿using DevExpress.Data.ODataLinq.Helpers;
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
        public List<Department> GetAll()
        {
            return _dbContext.Departments.ToList();
        }
        public List<Department> GetAllByCompanyId(Guid id)
        {
            return _dbContext.Departments.Where(x => x.Company.Id == id).ToList();
        }

        //Get
        public Department? Get(Guid id)
        {
            return _dbContext.Departments.Find(id);
        }

        //Create
        public bool Create(Department department)
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
        public bool Update(Department department)
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
        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
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
