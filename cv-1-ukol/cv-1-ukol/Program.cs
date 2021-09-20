using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_1_ukol {
	class Program {
		public static void PrintArray<T>(T[] arr) {
			int i = 1;
			foreach (T p in arr) {
				Console.WriteLine("{0}. {1}", i, p.ToString());
				i++;
			}
		}

		public static void Merge<T>(T[] list, T[] left, T[] right)
			where T : IComparable<T> {
			int i = 0, j = 0;

			while ((i < left.Length) && (j < right.Length)) {
				if (left[i].CompareTo(right[j]) < 0) {
					list[i + j] = left[i];
					i++;
				}
				else {
					list[i + j] = right[j];
					j++;
				}
			}
			
			if (i < left.Length) {
				while (i < left.Length) {
					list[i + j] = left[i];
					i++;
				}
			}
			else {
				while (j < right.Length) {
					list[i + j] = right[j];
					j++;
				}
			}
		}

		public static void ComparableMergeSort<T>(T[] arr)
			where T : IComparable<T> {
			if (arr.Length == 1) {
#if DEBUG
				Console.WriteLine(arr[0].ToString());
#endif
				return;
			}
			int center = arr.Length / 2;

			T[] left = new T[center];
			for (int i = 0; i < center; i++)
				left[i] = arr[i];

			T[] right = new T[arr.Length - center];
			for (int i = center; i < arr.Length; i++)
				right[i - center] = arr[i];

			ComparableMergeSort(left);
			ComparableMergeSort(right);

			Merge(arr, left, right);
		}






		static void Main(string[] args) {
			Player[] players = { new Player("Roman", 60, 16, 12, 4),
				new Player("Vaclav", 69, 14, 12, 5),
				new Player("Honza", 21, 19, 4, 3),
				new Player("Tomas", 3, 21, 5, 2),
				new Player("Jakub", 45, 34, 16, 8),
				new Player("Mirek", 88, 7, 23, 6),
				new Player("Martin", 68, 17, 11, 7),
				new Player("Radek", 23, 5, 8, 3),
				new Player("Marek", 48, 21, 7, 2),
				new Player("Michal", 96, 18, 1, 4), };

			PrintArray(players);
			Console.WriteLine();
			ComparableMergeSort(players);
#if DEBUG
			Console.WriteLine();
#endif
			PrintArray(players);
			Console.WriteLine("\nPhoenix: {0}:{1}",Properties.Settings.Default.ipAdd, Properties.Settings.Default.port);

			//int[] arr = { 0, 1, 2, 4, 5, 6, 7, 8, 6, 5, 4, 3, 5, 4, 6, 4 };
			//PrintArray(arr);
			//ComparableMergeSort(arr);
			//PrintArray(arr);

			Console.ReadKey();
		}
	}
}
