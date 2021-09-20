using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace cv_7_ukol {
   class Program {
      static void Main(string[] args) {
         // relativni cesta k db
         string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
         string path = (System.IO.Path.GetDirectoryName(executable));
         AppDomain.CurrentDomain.SetData("DataDirectory", path);



         path = @"..\..\studentiPredmetu.xml";
         try {
            // deserializace xml do objektu
            XmlSerializer deserializer = new XmlSerializer(typeof(studentiPredmetu));
            studentiPredmetu students;

            using (var reader = new StreamReader(path)) {
               students = (studentiPredmetu)deserializer.Deserialize(reader);
            }


            // nahodne znamky pro kazdeho studenta
            List<Exam> exams = Auxiliary.RandomExams(students);


            // vlozeni do db
            StudentsContext sc = new StudentsContext();
            foreach (var st in students.studentPredmetu) {
               sc.Students.Add(st);
            }

            foreach (var exam in exams) {
               sc.Exams.Add(exam);
            }
            sc.SaveChanges();


            // vypis 10 unikatnich dvojic
            foreach (var st in sc.Students.GroupBy(s => new { s.jmeno, s.prijmeni }).Select(s => new { s.Key.jmeno, s.Key.prijmeni }).OrderBy(s => s.prijmeni).Skip(4).Take(10)) {
               Console.WriteLine(st.jmeno + " " + st.prijmeni);
            }


            // pridani dvou studentu
            Student s1 = new Student("R69696", "Zorka", "Horka", "S", "horkzo01", 514, "Informatika", "PRF", "B1802", "P", "B", 7, "O", 3, 1, "INF", 45, "zorkahorka@upol.cz", "K938923", "Ž", "A", "B");
            Student s2 = new Student("R80085", "Kamil", "Vopršálek", "S", "voprka00", 514, "Informatika", "PRF", "B1802", "P", "B", 7, "O", 3, 1, "APLINF", 1037, "voprkami@upol.cz", "I483783", "M", "A", "B");

            sc.Students.Add(s1);
            sc.Students.Add(s2);

            sc.SaveChanges();


            // smazani studentu, kteri studuji INF
            foreach (var st in sc.Students.Where(s => s.oborKomb == "INF")) {
               sc.Students.Remove(st);
            }


            // zmena studenta
            var studentToChange = sc.Students.FirstOrDefault(s => s.osCislo == "R18601");
            if (studentToChange != null)
               studentToChange.userName = "stonda01";

            sc.SaveChanges();


            // vypis znamek
            var studentsGrades = (from st in sc.Students
                                  join e in sc.Exams
                                  on st.osCislo equals e.StudentOsCislo into g
                                  select new {
                                     Name = st.jmeno,
                                     Surname = st.prijmeni,
                                     Exams = g.Select(x => new { x.Subject, x.Grade })
                                  }).ToList();


            Console.WriteLine();
            foreach (var st in studentsGrades) {
               Console.WriteLine(st.Name + " " + st.Surname);
               if (st.Exams.Count() != 0) {
                  foreach (var g in st.Exams) {
                     Console.WriteLine(g.Subject + " - " + g.Grade);
                  }
               }
               else {
                  Console.WriteLine("This student doesn't have any grades");
               }
               Console.WriteLine();
            }

            sc.Dispose();
         }
         catch (Exception e) {
            Console.WriteLine(e.Message);
         }
         Console.ReadLine();
      }
   }
}
