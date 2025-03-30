using System.Diagnostics;

namespace RandomArrayGenerator
{
    public class ThreadArrayCounter
    {
        public (long Sum, long Speed) CalculateSum(int[] numbers)
        {
            var stopwatch = Stopwatch.StartNew();

            int threadCount = Environment.ProcessorCount;
            Console.WriteLine($"threadCount = {threadCount}");
            int batch = numbers.Length / threadCount;
            int totalSum = 0;
            object lockObj = new object();

            List<Thread> threadList = new List<Thread>(threadCount);

            for (int ti = 0; ti < threadCount; ti++)
            {
                int start = ti * batch;
                int end = (ti == threadCount - 1) ? numbers.Length : start + batch;

                Thread thread = new Thread(() =>
                {
                    int localSum = 0;
                    for (int j = start; j < end; j++)
                    {
                        localSum += numbers[j];
                    }

                    lock (lockObj)
                    {
                        totalSum += localSum;
                    }
                });

                threadList.Add(thread);
                thread.Start();
            }

            foreach (var thread in threadList)
            {
                thread.Join();
            }

            stopwatch.Stop();
            return (totalSum, stopwatch.ElapsedMilliseconds);
        }
    }
}
