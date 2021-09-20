using System;
using System.IO;

namespace cv_3_ukol {
	class PrintDriveInfo {
		/// <summary>
		/// Prints information about drives on the computer
		/// </summary>
		public static void PrintDrives() {
			Console.WriteLine("Drives on this computer:");
			Console.WriteLine("{0,-15}{1,-25}{2}", "Name", "Total Size", "Free Space");
			DriveInfo[] dinfos = DriveInfo.GetDrives();

			foreach (DriveInfo di in dinfos) {
				if (di.IsReady) {
					Console.WriteLine("{0,-15}{1,-25}{2}", di.Name, Math.Round(di.TotalSize / 1000000.0,2) + "MB", Math.Round(di.AvailableFreeSpace / 1000000.0,2) + "MB");
				}
			}
		}

		/// <summary>
		/// Prints the contents of specified directory with information about time of creation, size (for files) and name
		/// </summary>
		/// <param name="path">Path to the directory</param>
		public static void PrintDirectoryContents(string path) {
			try {
				DirectoryInfo dirinfo = null;
				if (path != "")
					dirinfo = new DirectoryInfo(path);
				else
					Console.WriteLine("Path must not be empty");

				if (dirinfo != null && dirinfo.Exists) {
					Console.WriteLine();
					PrintDirectories(dirinfo);
					PrintFiles(dirinfo);
				}
				else if(path!="") {
					Console.WriteLine("Directory {0} not found", path);
				}
			}
			catch (Exception e) {
				Console.WriteLine(e.Message);
			}
		}

		/// <summary>
		/// Prints information about subdirectories in a specified directory
		/// </summary>
		/// <param name="dirinfo"></param>
		static void PrintDirectories(DirectoryInfo dirinfo) {
			DirectoryInfo[] folders = dirinfo.GetDirectories();
			foreach (DirectoryInfo folder in folders) {
				if (folder.Exists) {
					Console.WriteLine("{0,-25}{1,-15}{2}", folder.CreationTime, "<dir>", folder.Name);
				}
			}
		}

		/// <summary>
		/// Prints information about files in a specified directory
		/// </summary>
		/// <param name="di"></param>
		static void PrintFiles(DirectoryInfo di) {
			FileInfo[] files = di.GetFiles();
			foreach (FileInfo file in files) {
				if (file.Exists) {
					Console.WriteLine("{0,-25}{1,-15}B{2}", file.CreationTime, file.Length, file.Name);
				}
			}
		}
	}
}
