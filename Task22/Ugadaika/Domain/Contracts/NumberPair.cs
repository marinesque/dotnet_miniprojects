namespace Ugadaika.Domain.Contracts
{
    public class NumberPair
    {
        private int _minNumber { get; }
        private int _maxNumber { get; }

        public NumberPair(int minNumber, int maxNumber)
        {
            if (minNumber > maxNumber)
                throw new Exception("Ошибка! Минимальное число больше максимального!");

            _maxNumber = maxNumber;
            _minNumber = minNumber;
        }
    }
}
