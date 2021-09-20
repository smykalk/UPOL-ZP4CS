using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_5_ukol {
	class ArrayPrinter {
		public static void PrintWithNumbers<T>(T[] arr) {
			int i = 1;
			foreach (T p in arr) {
				Console.WriteLine("{0}. {1}", i, p.ToString());
				i++;
			}
		}

		public static void Print<T>(T[] arr) {
			foreach (T p in arr) {
				Console.WriteLine("{0}", p.ToString());
			}
		}
	}
}
