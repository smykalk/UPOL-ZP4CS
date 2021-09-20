using System;
using System.IO;
using System.Xml;

namespace cv_4_ukol {
	class Program {
		static void Main(string[] args) {
			FileOperations.ReadStudentsWriteSecondYear(@"..\..\zp4cs04_data\studentiPredmetu.xml", @"..\..\exported_data\SecondYearStudents.json");
			FileOperations.ReadStudentsWritePeters(@"..\..\zp4cs04_data\uciteleKatedry.json", @"..\..\exported_data\TeachersNamedPetr.xml");
			FileOperations.DeserializeSubjectsWriteFirstN(@"..\..\zp4cs04_data\predmetyKatedry.xml", @"..\..\exported_data\FirstN.xml", 20);

			Console.WriteLine("done");
			Console.ReadLine();
		}
	}
}
