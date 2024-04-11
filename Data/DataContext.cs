using Authentication.Data.Models;
using Authentication.Migrations;
using Authentication.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;

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
        public DbSet<Sessiontable> sessiontables { get; set; }
        //public DbSet<StudentTable> studenttables { get; set; }
        public DbSet<RoomTable> roomTables { get; set; }
        public DbSet<StaffTable> staffTables { get; set; }
        public DbSet<StudentTable> studenttable { get; set; }
        public DbSet<StudenAttendanceTable> studenAttendanceTable { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Programetbl>()
                .HasKey(p => p.ProgrameId); // Define primary key here

          
            modelBuilder.Entity<Subjecttble>()
               .HasKey(p => p.SubjectID);

            modelBuilder.Entity<DesignationTable>()
               .HasKey(p => p.DesignationID);

            modelBuilder.Entity<Sessiontable>()
              .HasKey(p => p.SessionId);

            modelBuilder.Entity<RoomTable>()
              .HasKey(p => p.Id);

            modelBuilder.Entity<StaffTable>()
                .HasKey(s => s.Id);

            // Adding foreign key relationships
            modelBuilder.Entity<StaffTable>()
                .HasOne(s => s.DesignationTable)
                .WithMany()
                .HasForeignKey(s => s.Designation_ID)
                .IsRequired();

            modelBuilder.Entity<StudentTable>()
                .HasKey(s => s.Id); // Define primary key here

            modelBuilder.Entity<StudentTable>()
                .HasOne(s => s.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .IsRequired();

            modelBuilder.Entity<StudentTable>()
                .HasOne(s => s.Sessiontable)
                .WithMany()
                .HasForeignKey(p => p.Session_ID)
                .IsRequired();

            modelBuilder.Entity<StudentTable>()
                .HasOne(s => s.Programetbl)
                .WithMany()
                .HasForeignKey(p => p.Programe_ID)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<StudenAttendanceTable>()
              .HasKey(s => s.Id); // Define primary key here

            modelBuilder.Entity<StudenAttendanceTable>()
                .HasOne(s => s.StudentTable)
                .WithMany()
                .HasForeignKey(s=>s.Student_Id)
                .IsRequired();
        }
    }
}
