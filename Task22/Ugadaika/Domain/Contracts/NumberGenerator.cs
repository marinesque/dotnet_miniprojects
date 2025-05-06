using Ugadaika.Domain.Interfaces;

namespace Ugadaika.Domain.Contracts
{
    public class NumberGenerator : INumberGenerator
    {
        public int Generate(int minNumber, int maxNumber)
        {
            var curNumber = Random.Shared.Next(minNumber, maxNumber + 1);
            return curNumber;
        }
    }
}
