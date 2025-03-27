namespace RandomArrayGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество элементов массива: ");
            long length = int.Parse(Console.ReadLine());

            int[] numbers = new int[length];

            Random random = new Random();
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(1, 10);
            }

            var simpleCounter = new SimpleArrayCounter();
            var simpleResult = simpleCounter.CalculateSum(numbers);

            var threadCounter = new ThreadArrayCounter();
            var threadResult = threadCounter.CalculateSum(numbers);

            var taskCounter = new TaskArrayCounter();
            var taskResult = taskCounter.CalculateSum(numbers);

            var plinqCounter = new PLINQArrayCounter();
            var plinqResult = plinqCounter.CalculateSum(numbers);

            var parallelForCounter = new ParallelForArrayCounter();
            var parallelForResult = parallelForCounter.CalculateSum(numbers);

            Console.WriteLine("Простое суммирование:");
            Console.WriteLine($"результат: {simpleResult.Sum}");
            Console.WriteLine($"время:     {simpleResult.Speed} мс");

            Console.WriteLine("Thread суммирование:");
            Console.WriteLine($"результат: {threadResult.Sum}");
            Console.WriteLine($"время:     {threadResult.Speed} мс");

            Console.WriteLine("Task суммирование:");
            Console.WriteLine($"результат: {taskResult.Sum}");
            Console.WriteLine($"время:     {taskResult.Speed} мс");

            Console.WriteLine("PLINQ суммирование:");
            Console.WriteLine($"результат: {plinqResult.Sum}");
            Console.WriteLine($"время:     {plinqResult.Speed} мс");

            Console.WriteLine("Parallel.For суммирование:");
            Console.WriteLine($"результат: {taskResult.Sum}");
            Console.WriteLine($"время:     {taskResult.Speed} мс");

            Console.ReadLine();
        }
    }
}