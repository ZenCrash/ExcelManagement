using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FileAndFolder = ExcelManagement.DxBlazor.Data.Models.FileAndFolder;

namespace ExcelManagement.DxBlazor.Data
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<FileAndFolder> FileAndFolders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /* Company */
            modelBuilder.Entity<Company>() //self refrence
                .HasOne(p => p.CreatedBy)
                .WithMany(p => p.CreatedCompanys)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Company>() //self refrence
                .HasOne(p => p.UpdatedBy)
                .WithMany(p => p.UpdatedCompanys)
                .OnDelete(DeleteBehavior.SetNull);

            /* Person */
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Company)
                .WithMany(c => c.People)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Person>() //self refrence
                .HasOne(p => p.CreatedBy)
                .WithMany(p => p.CreatedPeople)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Person>() //self refrence
                .HasOne(p => p.UpdatedBy)
                .WithMany(p => p.UpdatedPeople)
                .OnDelete(DeleteBehavior.SetNull);

            /* Role */
            modelBuilder.Entity<Role>()
                .HasOne(r => r.Company)
                .WithMany(c => c.Roles)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Role>()
                .HasOne(r => r.CreatedBy)
                .WithMany(p => p.CreatedRoles)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Role>()
                .HasOne(r => r.UpdatedBy)
                .WithMany(p => p.UpdatedRoles)
                .OnDelete(DeleteBehavior.SetNull);

            /* Group */
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Company)
                .WithMany(c => c.Groups)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Group>()
                .HasOne(g => g.CreatedBy)
                .WithMany(p => p.CreatedGroups)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Group>()
                .HasOne(g => g.UpdatedBy)
                .WithMany(p => p.UpdatedGroups)
                .OnDelete(DeleteBehavior.SetNull);

            /* FileAndFolder */
            modelBuilder.Entity<FileAndFolder>()
                .HasOne(f => f.Company)
                .WithMany(c => c.FileAndFolders)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<FileAndFolder>()
                .HasOne(f => f.CreatedBy)
                .WithMany(p => p.CreatedFileAndFolders)
                .OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<FileAndFolder>()
                .HasOne(f => f.UpdatedBy)
                .WithMany(p => p.UpdatedFileAndFolders)
                .OnDelete(DeleteBehavior.SetNull);

            /* Brigde Tables */
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Roles)
                .WithMany(r => r.People);
            modelBuilder.Entity<Person>()
                .HasMany(p => p.FileAndFolders)
                .WithMany(r => r.People);
            modelBuilder.Entity<Role>()
                .HasMany(g => g.FileAndFolders)
                .WithMany(p => p.Roles);
            modelBuilder.Entity<Group>()
                .HasMany(g => g.FileAndFolders)
                .WithMany(p => p.Groups);
        }
    }
}
