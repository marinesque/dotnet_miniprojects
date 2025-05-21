using Ugadaika.Domain.Interfaces;

namespace Ugadaika.Domain.Contracts
{
    public class UgadaikaGame : IGamePlay
    {
        public INumberGenerator _generator;

        private int _minNumber;
        private int _maxNumber;

        public UgadaikaGame(INumberGenerator generator, int minNumber, int maxNumber)
        {
            _generator = generator;
            _minNumber = minNumber;
            _maxNumber = maxNumber;
        }

        public void Play()
        {
            int curNumber = _generator.Generate(_minNumber, _maxNumber);

            Console.WriteLine($"Я загадал число от {_minNumber} до {_maxNumber}. Угадай его:");

            var isNumber = int.TryParse(Console.ReadLine(), out int attempt);

            if (!isNumber)
                throw new Exception("Введи-ка ты число)");

            if (attempt == curNumber)
            {
                Console.WriteLine($"Угадал!");
                return;
            }
            else
            {
                Console.WriteLine($"Не угадал! Это было число {curNumber}");
            }
        }
    }
}
