using System;
using System.Collections.Generic;

namespace cv_7_ukol {
   class Auxiliary {
      public static List<Exam> RandomExams(studentiPredmetu students) {
         List <Exam> exams = new List<Exam>();
         Random random = new Random();

         foreach(Student stud in students.studentPredmetu) {
            exams.Add(new Exam("KMI/ALM2", stud.osCislo, (byte)random.Next(1, 4)));
            exams.Add(new Exam("KMI/PAPR1", stud.osCislo, (byte)random.Next(1, 4)));
            exams.Add(new Exam("KMI/ZP4CS", stud.osCislo, (byte)random.Next(1, 4)));
         }

         return exams;
      }
   }
}
