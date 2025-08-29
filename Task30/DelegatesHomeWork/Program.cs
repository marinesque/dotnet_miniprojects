class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Поиск файлов. Нажмите 'q' для отмены в любой момент.");
        Console.Write("Введите путь> ");
        string directoryPath = Console.ReadLine();

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Директория не существует!");
            Console.ReadKey();
            return;
        }

        var cts = new CancellationTokenSource();
        var fileWorker = new FileWorker();

        fileWorker.FileFound += (sender, e) =>
        {
            Console.WriteLine($">> {e.FileName}");
            if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
            {
                e.Cancel = true;
                cts.Cancel();
            }
        };

        //fileWorker.Search(directoryPath);
        var fileWorkerTask = Task.Run(() => fileWorker.Search(directoryPath, cts.Token));
        Task.Run(() =>
        {
            while (!fileWorkerTask.IsCompleted)
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    cts.Cancel();
                    break;
                }
            }
        });

        fileWorkerTask.Wait();

        if (!cts.IsCancellationRequested)
        {
            var files = Directory.EnumerateFiles(directoryPath, "*.*", SearchOption.AllDirectories)
                                     .Select(f => new FileInfo(f));

            var maxSizeFile = files.GetMax(f => f.Length);
            if (maxSizeFile != null)
            {
                Console.WriteLine($"\nМаксимальный по размеру файл: {maxSizeFile.FullName} ({maxSizeFile.Length} байт)");
            }
            else
            {
                Console.WriteLine("Директория пустая.");
            }
        }

        Console.ReadKey();
    }
}