//#define EXCEPTIONSTEST

using System;

namespace cv_3_ukol {
	class Program {
		static void Main(string[] args) {
			//drives and files
			PrintDriveInfo.PrintDrives();

			Console.Write("\n> Enter directory to list: ");
			PrintDriveInfo.PrintDirectoryContents(Console.ReadLine());

			Console.WriteLine();

			//binary matrices
			BinaryMatrix bm = new BinaryMatrix(new byte[,] { { 1, 1, 1 },
																			 { 0, 1, 0 },
																			 { 0, 1, 1 },
																			 { 0, 0, 1 } });


			Console.WriteLine(bm + "\n");
			bm[1, 0] = 0;
			Console.WriteLine(bm + "\n");
			bm.WriteMatrix
				("matrix.bin");

			BinaryMatrix bm2 = BinaryMatrix.ReadMatrix("matrix.bin");

			Console.WriteLine("Matrix read from file: ");
			Console.WriteLine(bm2);






            //testing exceptions
#if EXCEPTIONSTEST
			Console.WriteLine("\n\n");
			PrintDriveInfo.PrintDirectoryContents("");
			PrintDriveInfo.PrintDirectoryContents("XXXX");

			try {
				bm = new BinaryMatrix(-1, 2);
			}
			catch(Exception e) {
				Console.WriteLine(e.Message);
			}

			try {
				bm = new BinaryMatrix(new byte[,] { { 1, 1, 0 }, { 0, 1, 0 }, { 1, 1, 1 } });
				bm[2, 1] = 3;
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}

			BinaryMatrix bm3 = BinaryMatrix.ReadMatrix("asdf.bin");
#endif

            Console.WriteLine("string");
			Console.ReadLine();
		}
	}
}
