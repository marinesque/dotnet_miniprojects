using System.Diagnostics;

namespace RandomArrayGenerator
{
    public class ParallelForArrayCounter
    {
        public (long Sum, long Speed) CalculateSum(int[] numbers)
        {
            var stopwatch = Stopwatch.StartNew();
            long totalSum = 0;

            // Используем Parallel.For с thread-safe суммированием
            Parallel.For(0, numbers.Length,
                () => 0L, // Инициализация локальной суммы для каждого потока
                (i, loopState, localSum) =>
                {
                    return localSum + numbers[i]; // Накопление локальной суммы
                },
                localSum => // Финальная агрегация результатов
                {
                    Interlocked.Add(ref totalSum, localSum);
                });

            stopwatch.Stop();
            return (totalSum, stopwatch.ElapsedMilliseconds);
        }
    }
}
