using System;
using System.Linq;

namespace cv_5_ukol {
	class Program {
		static void Main(string[] args) {
			//"po staru"
			Student[] students = ReadonlyDB.Students;
			ComparableMergeSort.Sort(students);
			Student[] studentsFiveToFifteen = new Student[10];
			Array.Copy(students, 4, studentsFiveToFifteen, 0, 10);
			ArrayPrinter.PrintWithNumbers(studentsFiveToFifteen);

			Console.WriteLine();

			//LINQ
			//setrizeni studenti - vypis deseti
			Student[] students2 = ReadonlyDB.Students.Skip(4).Take(10).OrderBy(s => s.Prijmeni).ToArray();
			ArrayPrinter.PrintWithNumbers(students2);

			Console.WriteLine();

			//prvni student v >=5 rocniku
			Student studentInYearFiveOrMore = ReadonlyDB.Students.FirstOrDefault(s => s.Rocnik >= 5);
			if (studentInYearFiveOrMore == null) {
				Console.WriteLine("There is no student that matches the condition");
			}
			else {
				Console.WriteLine(studentInYearFiveOrMore);
			}


			Console.WriteLine();

			//pocet studentu s OborKomb == "INF"
			Console.WriteLine("Students with OborKomb == \"INF\": {0}", ReadonlyDB.Students.Where(s => s.OborKomb == "INF").Count());

			Console.WriteLine();

			//existuje osoba jmenem lukas?
			string nameToMatch = "Lukáš";
			if (ReadonlyDB.Students.Any(s => s.Jmeno == nameToMatch)) {
				Console.WriteLine($"Student with the name {nameToMatch} exists");
			}
			else {
				Console.WriteLine($"Student with the name {nameToMatch} doesn't exist");
			}

			Console.ReadLine();
		}
	}
}
