using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv_5_ukol {
	class ComparableMergeSort {
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

		public static void Sort<T>(T[] arr)
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

			Sort(left);
			Sort(right);

			Merge(arr, left, right);
		}
	}
}
