﻿using Microsoft.EntityFrameworkCore;
using testing.Domain.Entities;
using testing.Domain.Entities.ContextEntities;

namespace Infraestructure.Context
{
    public class AplicationContext : DbContext
    {
        public DbSet<UserSchedule> Schedules { get; set; }
        public DbSet<TeacherSubject> TeacherSubject { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Degree> Degree { get; set; }
        public DbSet<DegreeSubject> DegreeSubject { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<ClassRoomSubject> ClassRoomSubject { get; set; }
        public DbSet<UserDegree> UserDegrees { get; set; }
        public DbSet<UserScheduleSection> ScheduleSections { get; set; }
        public DbSet<DayOfTheWeek> DayOfTheWeek { get; set; }

        public AplicationContext()
        {
            
        }
        public AplicationContext(DbContextOptions<AplicationContext> options) : base (options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=IBSCOMP124; user Id=sa; password=biblia01**;  Database=testingApplication; TrustServerCertificate=true;", m => m.MigrationsAssembly(typeof(AplicationContext).Assembly.FullName));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Subject>(s =>
            {

            });
        }
    }
}
