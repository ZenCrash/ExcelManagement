using ExcelManagement.DxBlazor.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
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

            /* Application -User -Role */
            modelBuilder.Entity<ApplicationUser>()
                .HasOne(au => au.Person)
                .WithOne(p => p.ApplicationUser);
            modelBuilder.Entity<ApplicationRole>()
                .HasOne(au => au.Role)
                .WithOne(r => r.ApplicationRole);

            /* Company */
            modelBuilder.Entity<Company>()
                .HasOne(p => p.CreatedBy)
                .WithMany(p => p.CreatedCompanys);
            modelBuilder.Entity<Company>()
                .HasOne(p => p.UpdatedBy)
                .WithMany(p => p.UpdatedCompanys);

            /* Person */
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Persons)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Person>() //self refrence
                .HasOne(p => p.CreatedBy)
                .WithMany(p => p.CreatedPersons);
            modelBuilder.Entity<Person>() //self refrence
                .HasOne(p => p.UpdatedBy)
                .WithMany(p => p.UpdatedPersons);

            /* Role */
            modelBuilder.Entity<Role>()
                .HasOne(r => r.Company)
                .WithMany(c => c.Roles)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Role>()
                .HasOne(r => r.CreatedBy)
                .WithMany(p => p.CreatedRoles);
            modelBuilder.Entity<Role>()
                .HasOne(r => r.UpdatedBy)
                .WithMany(p => p.UpdatedRoles);

            /* Group */
            modelBuilder.Entity<Group>()
                .HasOne(g => g.Company)
                .WithMany(c => c.Groups)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Group>()
                .HasOne(g => g.CreatedBy)
                .WithMany(p => p.CreatedGroups);
            modelBuilder.Entity<Group>()
                .HasOne(g => g.UpdatedBy)
                .WithMany(p => p.UpdatedGroups);

            /* FileAndFolder */
            modelBuilder.Entity<FileAndFolder>()
                .HasOne(f => f.Company)
                .WithMany(c => c.FileAndFolders)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<FileAndFolder>()
                .HasOne(f => f.CreatedBy)
                .WithMany(p => p.CreatedFileAndFolders);
            modelBuilder.Entity<FileAndFolder>()
                .HasOne(f => f.UpdatedBy)
                .WithMany(p => p.UpdatedFileAndFolders);

            /* Brigde Tables */
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Roles)
                .WithMany(r => r.Persons)
                .UsingEntity("PeopleRoles");

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Groups)
                .WithMany(g => g.Persons)
                .UsingEntity(j => j.ToTable("PeopleGroups"));

            modelBuilder.Entity<Person>()
                .HasMany(p => p.FileAndFolders)
                .WithMany(f => f.Persons)
                .UsingEntity(j => j.ToTable("FileAndFoldersPeople"));
            modelBuilder.Entity<Role>()
                .HasMany(r => r.FileAndFolders)
                .WithMany(f => f.Roles)
                .UsingEntity(j => j.ToTable("FileAndFoldersRoles"));
            modelBuilder.Entity<Group>()
                .HasMany(g => g.FileAndFolders)
                .WithMany(f => f.Groups)
                .UsingEntity(j => j.ToTable("FileAndFoldersGroups"));

        }
    }
}