using System.Diagnostics;

namespace RandomArrayGenerator
{
    public class SimpleArrayCounter
    {
        public (long Sum, TimeSpan Speed) CalculateSum(int[] numbers)
        {
            var stopwatch = Stopwatch.StartNew();

            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            stopwatch.Stop();

            return (sum, stopwatch.Elapsed);
        }
    }
}