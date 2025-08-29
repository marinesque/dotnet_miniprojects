public class FileWorker
{
    public event EventHandler<FileArgs> FileFound;
    private CancellationTokenSource _cancellationTokenSource;

    protected virtual void OnFileFound(FileArgs e)
    {
        FileFound?.Invoke(this, e);
    }

    public void Search(string directory, CancellationToken cancellationToken = default)
    {
        foreach (var file in Directory.EnumerateFiles(directory, "*.*", SearchOption.AllDirectories))
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Поиск отменён.");
                return;
            }

            var args = new FileArgs { FileName = file };

            OnFileFound(args);

            if (args.Cancel || cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Поиск отменён.");
                return;
            }
        }
    }

    public void CancelSearch()
    {
        _cancellationTokenSource?.Cancel();
    }
}