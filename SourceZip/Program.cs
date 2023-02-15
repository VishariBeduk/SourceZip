using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;

namespace SourceZip
{
	internal class Program
	{
		static void Main(string[] args)
		{
			if (args.Length == 0)
			{
				Console.WriteLine("Supply directory name.");
				return;
			}

			string path = CleanPath(args[0]);
			if (!Directory.Exists(path))
			{
				Console.WriteLine("Directory does not exist");
				return;
			}
			int basePathLength = path.Length + 1;

			string destinationFile = OutputFileName(path);
			Console.WriteLine($"Compress contents of {path} into {destinationFile}");

			using (var zip = ZipFile.Open(destinationFile, ZipArchiveMode.Create))
			{
				TraverseFileSystem tfs = new();
				foreach (string fileName in tfs.GetNextFile(path))
				{
					string shortFileName = fileName.Substring(basePathLength);
					Console.WriteLine(shortFileName);
					zip.CreateEntryFromFile(fileName, shortFileName, CompressionLevel.Optimal);
				}
			}
		}

		private static string CleanPath(string path)
		{
			string s = path.Trim();
			if (s.EndsWith(Path.DirectorySeparatorChar))
			{
				s = s.Substring(0, s.Length - 1);
			}

			return s;
		}

		private static string OutputFileName(string path)
		{
			if (string.IsNullOrWhiteSpace(path))
			{
				return string.Empty;
			}

			int pos = 1 + path.LastIndexOf(Path.DirectorySeparatorChar);
			DateTime today = DateTime.Now;

			return
				path.Substring(0, pos) +
				today.ToString("yyyyMMddHHmm") +
				"-" +
				path.Substring(pos) +
				".zip";
		}
	}
}