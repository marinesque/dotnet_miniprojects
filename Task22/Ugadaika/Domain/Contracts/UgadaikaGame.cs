using Ugadaika.Domain.Interfaces;

namespace Ugadaika.Domain.Contracts
{
    public class UgadaikaGame : INumberGenerator, INumberValidator
    {
        public INumberGenerator _generator;
        private NumberPair _numberPair;

        public UgadaikaGame(INumberGenerator generator, NumberPair numberPair)
        {
            _generator = generator;
            _numberPair = numberPair;
        }

        public int Generate(int minNumber, int maxNumber)
        {
            throw new NotImplementedException();
        }

        public bool Validate(int curNumber, int minNumber, int maxNumber)
        {
            throw new NotImplementedException();
        }
    }
}
