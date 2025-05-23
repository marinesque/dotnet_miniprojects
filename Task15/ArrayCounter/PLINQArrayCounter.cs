﻿using System.Diagnostics;

namespace RandomArrayGenerator
{
    public class PLINQArrayCounter
    {
        public (long Sum, long Speed) CalculateSum(int[] numbers)
        {
            var stopwatch = Stopwatch.StartNew();

            long sum = numbers.AsParallel().Sum(x => (long)x);

            stopwatch.Stop();

            return (sum, stopwatch.ElapsedMilliseconds);
        }
    }
}