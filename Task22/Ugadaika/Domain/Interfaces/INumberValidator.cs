namespace Ugadaika.Domain.Interfaces
{
    public interface INumberValidator
    {
        public bool Validate(int curNumber, int minNumber, int maxNumber);
    }
}
