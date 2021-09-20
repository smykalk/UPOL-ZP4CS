using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cv_7_ukol {
   class Exam {
      [Key] [Column(Order = 1)] public string Subject { get; set; }
      [Key] [Column(Order = 2)] public string StudentOsCislo { get; set; }
      public byte Grade { get; set; }

      public Exam(string subject, string studentOsCislo, byte grade) {
         Subject = subject;
         StudentOsCislo = studentOsCislo;
         Grade = grade;
      }
   }
}
