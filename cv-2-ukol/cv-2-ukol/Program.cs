using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace cv_2_ukol {

	class Program {
		public static void PrintArray<T>(T[] arr) {
			int i = 1;
			foreach (T p in arr) {
				Console.WriteLine("{0}. {1}", i, p.ToString());
				i++;
			}
		}

		public static void Merge<T>(T[] arr, T[] left, T[] right)
			where T : IComparable<T> {
			int i = 0, j = 0;

			while ((i < left.Length) && (j < right.Length)) {
				if (left[i].CompareTo(right[j]) < 0) {
					arr[i + j] = left[i];
					i++;
				}
				else {
					arr[i + j] = right[j];
					j++;
				}
			}

			if (i < left.Length) {
				while (i < left.Length) {
					arr[i + j] = left[i];
					i++;
				}
			}
			else {
				while (j < right.Length) {
					arr[i + j] = right[j];
					j++;
				}
			}
		}

		public static bool CheckIfSorted(int[] array) {
			for (int i = 0; i < array.Length - 1; i++) {
				if (array[i] > array[i + 1])
					return false;
			}
			return true;
		}

		/// <summary>
		/// Sorts the given array using MergeSort. Uses parallelization until given depth is reached. Then sorts sequentially.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="arr"></param>
		/// <param name="depth"></param>
		public static void ParallelMergeSort<T>(T[] arr, int depth)
			where T : IComparable<T> {
			if (arr.Length == 1) {
				return;
			}
			int center = arr.Length / 2;

			T[] left = new T[center];
			for (int i = 0; i < center; i++)
				left[i] = arr[i];

			T[] right = new T[arr.Length - center];
			for (int i = center; i < arr.Length; i++)
				right[i - center] = arr[i];

			if (depth > 0) {
				depth--;

				//Parallel.Invoke(
				//	() => ParallelMergeSort(arr, depth),
				//	() => ParallelMergeSort(arr, depth)
				//	);

				//Melo by byt ekvivalentni

				//pulka pole do jednoho threadu, druha pulka do druheho
				Thread t1 = new Thread(() => ParallelMergeSort(arr, depth));
				Thread t2 = new Thread(() => ParallelMergeSort(arr, depth));
				t1.Start();
				t2.Start();

				//cekani
				t1.Join();
				t2.Join();
			}
			else {
				ParallelMergeSort(left, depth);
				ParallelMergeSort(right, depth);
			}
			Merge(arr, left, right);
		}

		public static int[] GetRandomArray(int length) {
			int[] arr = new int[length];
			Random random = new Random();
			for (int i = 0; i < length; i++) {
				arr[i] = random.Next();
			}
			return arr;
		}

		static void Main(string[] args) {
			//hloubka 0
			int[] array = GetRandomArray(10000000);
			Stopwatch sw = Stopwatch.StartNew();
			ParallelMergeSort(array, 0);
			sw.Stop();
#if DEBUG
			Console.WriteLine(CheckIfSorted(array));
#endif
			Console.WriteLine("Hloubka: 0, Cas behu: {0}\n", sw.ElapsedMilliseconds/1000.0);

			//hloubka 1
			array = GetRandomArray(10000000);
			sw = Stopwatch.StartNew();
			ParallelMergeSort(array, 1);
			sw.Stop();
#if DEBUG
			Console.WriteLine(CheckIfSorted(array));
#endif
			Console.WriteLine("Hloubka: 1, Cas behu: {0}\n", sw.ElapsedMilliseconds/1000.0);

			//hloubka 2
			array = GetRandomArray(10000000);
			sw = Stopwatch.StartNew();
			ParallelMergeSort(array, 2);
			sw.Stop();
#if DEBUG
			Console.WriteLine(CheckIfSorted(array));
#endif
			Console.WriteLine("Hloubka: 2, Cas behu: {0}\n", sw.ElapsedMilliseconds/1000.0);

			//hloubka 3
			array = GetRandomArray(10000000);
			sw = Stopwatch.StartNew();
			ParallelMergeSort(array, 3);
			sw.Stop();
#if DEBUG
			Console.WriteLine(CheckIfSorted(array));
#endif
			Console.WriteLine("Hloubka: 3, Cas behu: {0}\n", sw.ElapsedMilliseconds/1000.0);


			Console.ReadKey();
		}
	}
}
