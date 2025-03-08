using System;

namespace ParallelProcessing
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Надо использовать команду dotnet run <таков_путь>");
                return;
            }

            var generator = new TextFileGenerator();

            string path = args[0];

            string file1Name = "text1.txt";
            generator.SaveToFile(path, file1Name, 100000);

            string file2Name = "text2.txt";
            generator.SaveToFile(path, file2Name, 200000);

            string file3Name = "text3.txt";
            generator.SaveToFile(path, file3Name, 300000);

            var spaceCounter = new SpaceCounter();

            spaceCounter.CountSpacesInFiles(path);
        }
    }
}
