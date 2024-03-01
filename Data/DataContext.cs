using Authentication.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Programetbl> ProgrameTables { get; set; }
        public DbSet<Subjecttble> SubjectTables { get; set; }
        public DbSet<DesignationTable> DesignationTable{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Programetbl>()
                .HasKey(p => p.ProgrameId); // Define primary key here

            modelBuilder.Entity<Programetbl>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired();
            modelBuilder.Entity<Subjecttble>()
               .HasKey(p => p.SubjectID);

            modelBuilder.Entity<DesignationTable>()
               .HasKey(p => p.DesignationID);
            
        }
    }
}
