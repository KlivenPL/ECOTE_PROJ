using ECOTE_PROJ.Interpretation;
using ECOTE_PROJ.Tokenization;
using System;
using System.IO;
using System.Reflection;

namespace ECOTE_PROJ {
    internal class Program {
        static void Main(string[] args) {
            if (args.Length != 1 && args.Length != 2) {
                PrintUsage();
                return;
            }

            var inputFilePath = args[0];
            var outputFilePath = args.Length > 1 ? args[1] : Path.ChangeExtension(inputFilePath, "csv");

            string dependencies;

            try {
                dependencies = FindDependencies(inputFilePath);
            } catch (FileNotFoundException) {
                Console.Error.WriteLine($"Input file not found: {new FileInfo(inputFilePath).FullName}");
                return;
            } catch (Exception ex) {
                Console.Error.WriteLine($"Unexpected exception while finding dependencies:{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                return;
            }

            try {
                SaveToFile(outputFilePath, dependencies);
                Console.WriteLine($"Output saved to: {outputFilePath}");
            } catch (Exception ex) {
                Console.Error.WriteLine($"Unexpected exception while saving output file:{Environment.NewLine}{ex.Message}{Environment.NewLine}{ex.StackTrace}");
                return;
            }
        }

        private static string FindDependencies(string filePath) {
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Exists) {
                throw new FileNotFoundException();
            }

            using var stream = fi.OpenRead();
            using var reader = new StreamReader(stream);
            var input = reader.ReadToEnd();

            var codeReader = new CodeReader(input);
            var tokenReader = new TokenReader(new Tokenizer().Tokenize(codeReader));

            return new InterpretationRoutine().FindPublicDataMemberDependencies(tokenReader);
        }

        private static void SaveToFile(string filePath, string output) {
            var fileInfo = new FileInfo(filePath);

            if (fileInfo.Exists) {
                fileInfo.Delete();
            }

            using var stream = fileInfo.OpenWrite();
            using var sw = new StreamWriter(stream);

            sw.Write(output);
        }

        private static void PrintUsage() {
            var codeBase = Assembly.GetExecutingAssembly().Location;
            var exeName = Path.GetFileNameWithoutExtension(Path.GetFileName(codeBase));

            Console.WriteLine("C++ data member dependency finder by Oskar Hącel");
            Console.WriteLine("ECOTE, Politechnika Warszawska 05.2022");
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine($"\t{exeName} <input_file_path> [output_file_path]");
            Console.WriteLine();
            Console.WriteLine($"Examples:");
            Console.WriteLine($"\t{exeName} hello_world.cpp");
            Console.WriteLine($"\t{exeName} hello_world.cpp hello_world_deps.csv");
            Console.WriteLine($"\t{exeName} \"file with spaces.cpp\" \"file with spaces deps.csv\"");
        }
    }
}
