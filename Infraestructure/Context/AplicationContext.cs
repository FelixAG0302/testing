using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Domain.Entities;

namespace Infraestructure.Context
{
    public class AplicationContext : DbContext
    {
        public DbSet<UserSchedule> Schedules { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherSubject> TeacherSubject { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Degree> Degree { get; set; }
        public DbSet<DegreeSubject> DegreeSubject { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<ClassRoomSubject> ClassRoomSubject { get; set; }


        public AplicationContext()
        {
            
        }
        public AplicationContext(DbContextOptions<AplicationContext> options) : base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserSchedule>( u =>
            {
                u.HasKey(u => u.Id);
               
            });
        }
    }
}
