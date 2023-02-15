using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SourceZip
{
	public class Configuration
	{
		public static string[] CodeExtensions = new string[]
		{
			".cs",
			".txt",
			".csproj",
			".json",
			".md",
			".sln",
			".asax",
			".resx",
			".manifest",
			".datasource",
			".settings",
			".map",
			".xml",
			".xsd",
			".xsx",
			".asax",
			".svc",
			".xaml",

			".yml",

			".ts",
			".html",
			".css",

			".cpp",
			".h",

			".sql",
			".bat",
			".config",
		};

		public static string[] DirectoriesIgnored = new string[]
		{
			"bin",
			"obj",
			".vs",
			".git",
			"node_modules",
			"dist",
			"packages"
		};
	}
}
