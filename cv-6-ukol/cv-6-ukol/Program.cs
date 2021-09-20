using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_6_ukol {
   class Program {
      public static int AddStudent(string osCislo, string jmeno, string prijmeni, string userName, int rocnik, string oborKomb, SqlConnection conn) {
         SqlCommand command = new SqlCommand("INSERT INTO students (OsCislo, Jmeno, Prijmeni, UserName, Rocnik, OborKomb) VALUES (@OsCislo, @Jmeno, @Prijmeni, @UserName, @Rocnik, @OborKomb)", conn);
         command.Parameters.Add(new SqlParameter("OsCislo", osCislo));
         command.Parameters.Add(new SqlParameter("Jmeno", jmeno));
         command.Parameters.Add(new SqlParameter("Prijmeni", prijmeni));
         command.Parameters.Add(new SqlParameter("UserName", userName));
         command.Parameters.Add(new SqlParameter("Rocnik", rocnik));
         command.Parameters.Add(new SqlParameter("OborKomb", oborKomb));

         return command.ExecuteNonQuery();
      }


      static void Main(string[] args) {
         try {
            using (SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\db.mdf;Integrated Security=True;Connect Timeout=30")) {
               conn.Open();

               // ukol 1
               SqlCommand command = new SqlCommand("SELECT Jmeno, Prijmeni FROM students ORDER BY Prijmeni;", conn);
               using (SqlDataReader dr = command.ExecuteReader()) {
                  string lastStudent = "";
                  int studentCounter = 0;
                  while (dr.Read()) {
                     if (studentCounter >= 4 && studentCounter <= 13) {
                        if ((dr[0].ToString() + dr[1].ToString()) != lastStudent) {
                           Console.WriteLine($"{dr[0]} {dr[1]}");
                        }
                        lastStudent = dr[0].ToString() + dr[1].ToString();
                        studentCounter++;
                     }
                     else
                        studentCounter++;
                  }
               }

               
               // ukol 2
               int affected = AddStudent("R69696", "Alois", "FRIDRICH", "fridal01", 3, "APLINF", conn);
               affected += AddStudent("R54456", "Zorka", "HORKÁ", "horkzo00", 2, "INF", conn);
               Console.WriteLine($"\n{affected} student(s) added");


               // ukol 3
               command = new SqlCommand("DELETE FROM students WHERE OborKomb='INF'", conn);
               affected = command.ExecuteNonQuery();
               Console.WriteLine($"\n{affected} student(s) deleted");


               // ukol 4
               command = new SqlCommand("UPDATE students SET UserName='stonda01' WHERE OsCislo='R18601'", conn);
               affected = command.ExecuteNonQuery();
               Console.WriteLine($"\n{affected} student(s) changed");

               command = new SqlCommand("SELECT * FROM students WHERE OsCislo='R18601'", conn);
               using (SqlDataReader dr = command.ExecuteReader()) {
                  dr.Read();
                  Console.WriteLine($"{dr[1]} {dr[2]} {dr[3]}");
               }
               Console.WriteLine();


               //ukol 5
               command = new SqlCommand("SELECT * FROM students", conn);
               List<Student> students = new List<Student>();

               //add students to list
               using (SqlDataReader dr = command.ExecuteReader()) {
                  while (dr.Read()) {
                     students.Add(new Student(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), int.Parse(dr[4].ToString()), dr[5].ToString()));
                  }
               }

               //print individual grades for all students
               Console.WriteLine("Grades for students:");
               foreach (Student stud in students) {
                  command = new SqlCommand("SELECT * FROM exams WHERE StudentOsCislo=@osCislo ORDER BY Subject", conn);
                  command.Parameters.Add(new SqlParameter("osCislo", stud.osCislo));
                  using (SqlDataReader dr = command.ExecuteReader()) {
                     if (dr.HasRows) {
                        Console.WriteLine(stud.ToString() + ":");
                        while (dr.Read()) {
                           Console.WriteLine($"{dr[0]} - {dr[2]}");
                        }
                        Console.WriteLine();
                     }
                  }
               }
            }
         }

         catch (Exception e) {
            Console.WriteLine(e.Message);
         }

         Console.ReadKey();
      }

   }
}