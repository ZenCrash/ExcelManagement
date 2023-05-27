using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExcelManagement.DxBlazor.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Department> Department { get; set; }
        
    }
}
