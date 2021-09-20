using System;
using System.Data.Entity;

namespace cv_7_ukol {
   class StudentsContext : DbContext {
      public StudentsContext() : base("StudentsDB") { }
      public DbSet<Student> Students { get; set; }
      public DbSet<Exam> Exams { get; set; }
   }
}
