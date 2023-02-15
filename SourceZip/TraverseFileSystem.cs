namespace SourceZip
{
	public class TraverseFileSystem
	{
		public IEnumerable<string> GetNextFile(string root)
		{
			Stack<string> dirs = new Stack<string>(20);
			string[] subDirs = new string[0];
			string[] files = new string[0];

			if (!Directory.Exists(root))
			{
				yield break;
			}
			dirs.Push(root);

			while (dirs.Any())
			{
				string currentDir = dirs.Pop();

				try
				{
					subDirs = Directory.GetDirectories(currentDir);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}

				foreach (string str in subDirs)
				{
					string[] subfolders = str.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries);
					string lastFolderName = subfolders.Last();
					if (!Array.Exists(Configuration.DirectoriesIgnored, element => element == lastFolderName))
					{
						dirs.Push(str);
					}
				}

				try
				{
					files = Directory.GetFiles(currentDir);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
				}

				foreach (string file in files)
				{
					string extension = Path.GetExtension(file).ToLower();
					if (Array.Exists(Configuration.CodeExtensions, element => element == extension))
					{
						yield return file;
					}
				}
			}
		}
	}
}
