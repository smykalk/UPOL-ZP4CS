using System;
using System.IO;

namespace cv_3_ukol {
	class BinaryMatrix {
		#region matrix implementation
		byte[,] matrix;

		//columns
		public ushort N {
			get { return (ushort)matrix.GetLength(1); }
		}

		//lines
		public ushort M {
			get { return (ushort)matrix.GetLength(0); }
		}

		/// <summary>
		/// Initializes binary matrix of specified dimensions
		/// </summary>
		/// <param name="n">Number of columns</param>
		/// <param name="m">Number of lines</param>
		public BinaryMatrix(int n, int m) {
			if (n < 0 || m < 0)
				throw new ArgumentException("Matrix dimensions must be positive");
			matrix = new byte[m, n];
		}

		/// <summary>
		/// Initializes binary matrix with specified contents
		/// </summary>
		/// <param name="contents"></param>
		public BinaryMatrix(byte[,] contents) {
			matrix = contents;
		}

		/// <summary>
		/// Access elements of a matrix based on indices
		/// </summary>
		/// <param name="i"></param>
		/// <param name="j"></param>
		/// <returns></returns>
		public byte this[int i, int j] {
			get { return matrix[j, i]; }
			set {
				if (value == 0 || value == 1)
					matrix[j, i] = value;
				else
					throw new ArgumentException("Value must be 0 or 1");
			}
		}
		#endregion


		#region binary read/write
		/// <summary>
		/// Writes the matrix in binary format to a specified file
		/// </summary>
		/// <param name="path"></param>
		public void WriteMatrix(string path) {
			try {
				using (BinaryWriter bw = new BinaryWriter(File.Create(@path))) {
					bw.Write(this.N);
					bw.Write(this.M);

					for (int j = 0; j < this.M; j++) {
						for (int i = 0; i < this.N; i++) {
							bw.Write(this[i, j]);
						}
					}

					bw.Flush();
				}
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}

		/// <summary>
		/// Reads matrix from a specified binary file
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static BinaryMatrix ReadMatrix(string path) {
			BinaryMatrix bm = null;

			try {
				using (BinaryReader br = new BinaryReader(File.OpenRead(@path))) {
					ushort n, m;
					n = br.ReadUInt16();
					m = br.ReadUInt16();
					bm = new BinaryMatrix(n, m);

					for (int j = 0; j < m; j++) {
						for (int i = 0; i < n; i++) {
							bm[i, j] = br.ReadByte();
						}
					}
				}
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}

			return bm;
		}
		#endregion


		public override string ToString() {
			string str = "";

			for (int j = 0; j < this.M; j++) {
				for (int i = 0; i < this.N; i++) {
					str += this[i, j];
					if (i + 1 < this.N)
						str += " ";
				}
				if (j + 1 < this.M)
					str += "\n";
			}

			return str;
		}
	}
}
