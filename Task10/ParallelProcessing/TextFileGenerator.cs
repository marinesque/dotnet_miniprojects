using System;
using System.IO;
using System.Text;

namespace ParallelProcessing
{
    public class TextFileGenerator
    {
        private static readonly string[] Words = new[]
        {
            "abra", "kadabra", "sim", "salabim", "ahalai", "mahalai", "kribli", "krabli", "booms", "vzhuh"
        };

        private static readonly Random Random = new Random();

        public string GenerateRandomText(int wordCount)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < wordCount; i++)
            {
                sb.Append(Words[Random.Next(Words.Length)]);
                if (i < wordCount - 1)
                {
                    sb.Append(" ");
                }
            }
            return sb.ToString();
        }

        public void SaveToFile(string path, string fileName, int wordCount)
        {
            string text = GenerateRandomText(wordCount);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, fileName);

            File.WriteAllText(filePath, text);

            Console.WriteLine($"Файл сгенерирован: {filePath}");
        }
    }
}