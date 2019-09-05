using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Mono.Cecil;
using Mono.Cecil.Mdb;
using Mono.Cecil.Pdb;

namespace PdbToMdb
{
	internal class Program
	{
		private static string Usage()
		{
			var parameters = "<DLL path>";

#if NETCOREAPP
			return $"Usage: dotnet PdbToMdb.dll {parameters}";
#else
			var prefix = Type.GetType("Mono.Runtime") != null ? "mono " : "";
			return $"Usage: {prefix}PdbToMdb.exe {parameters}";
#endif
		}

		public static int Main(string[] args)
		{
			if (args.Length != 1)
			{
				Console.Error.WriteLine(Usage());
				return -1;
			}

			if (args[0].ToLower().EndsWith("help"))
			{
				Console.WriteLine(Usage());
				return 0;
			}

			var assemblyFile = args[0];

			var resolver = new DefaultAssemblyResolver();
			resolver.AddSearchDirectory(Path.GetDirectoryName(assemblyFile));

			var readerParams = new ReaderParameters {
				AssemblyResolver = resolver,
				ReadSymbols = true,
				ReadWrite = true,
				SymbolReaderProvider = new PdbReaderProvider(),
			};

			using (var assembly = AssemblyDefinition.ReadAssembly(assemblyFile, readerParams))
			{
				var writerParams = new WriterParameters {
					SymbolWriterProvider = new MdbWriterProvider(),
					WriteSymbols = true,
				};

				assembly.Write(writerParams);
			}

			Console.WriteLine("Done");
			return 0;
		}
	}
}
