using System.Diagnostics;

namespace RandomArrayGenerator
{
    public class TaskArrayCounter
    {
        public (long Sum, long Speed) CalculateSum(int[] numbers)
        {
            var stopwatch = Stopwatch.StartNew();

            int threadCount = Environment.ProcessorCount;
            var batch = numbers.Chunk(numbers.Length / threadCount + 1);

            var tasks = batch.Select(b => Task.Run(() =>
            {
                long localSum = 0;
                foreach (var num in b)
                {
                    localSum += num;
                }
                return localSum;
            })).ToArray();

            long totalSum = 0;
            Task.WhenAll(tasks).ContinueWith(t =>
            {
                foreach (var task in tasks)
                {
                    totalSum += task.Result;
                }
            }).Wait();

            stopwatch.Stop();
            return (totalSum, stopwatch.ElapsedMilliseconds);
        }
    }
}
