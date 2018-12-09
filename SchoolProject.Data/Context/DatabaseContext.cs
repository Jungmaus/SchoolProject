using SchoolProject.Data.Entities;
using SchoolProject.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.Connection.ConnectionString = @"Data Source=DESKTOP-CE1GVBQ\SQLEXPRESS;Initial Catalog=SchoolProjectDB;Integrated Security=True;MultipleActiveResultSets=True";
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonDetail> LessonDetails { get; set; }
        public DbSet<LessonStudentMeeting> LessonStudentMeetings { get; set; }
        public DbSet<LessonTeacherPost> LessonTeacherPosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new LessonMap());
            modelBuilder.Configurations.Add(new LessonDetailMap());
            modelBuilder.Configurations.Add(new LessonStudentMeetingMap());
            modelBuilder.Configurations.Add(new LessonTeacherPostMap());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

    }
}
