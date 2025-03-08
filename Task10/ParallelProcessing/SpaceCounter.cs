using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ParallelProcessing
{
    public class SpaceCounter
    {
        public void CountSpacesInFiles(string path)
        {
            string[] files = Directory.GetFiles(path);
            if (files.Length == 0)
            {
                Console.WriteLine($"Файлы не найдены в '{path}'");
                return;
            }

            Task[] tasks = new Task[files.Length];

            for (int i = 0; i < files.Length; i++)
            {
                string filePath = files[i];
                tasks[i] = Task.Run(() => CountSpacesInFile(filePath));
            }

            Task.WaitAll(tasks);
            
        }

        private void CountSpacesInFile(string filePath)
        {

            Stopwatch stopwatch = Stopwatch.StartNew();

            string content = File.ReadAllText(filePath);
            var count = content.Count(symbol => symbol == ' ');

            stopwatch.Stop();

            Console.WriteLine($"файл:      {filePath}:");
            Console.WriteLine($" пробелов: {count}");
            Console.WriteLine($" время:    {stopwatch.Elapsed} мс");

        }
    }
}