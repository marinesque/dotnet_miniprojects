namespace Ugadaika.Domain.Contracts
{
    public class EvenNumberGenerator : NumberGenerator
    {
        public override int Generate(int minNumber, int maxNumber)
        {
            Validate(minNumber, maxNumber);

            int number;
            do
            {
                number = base.Generate(minNumber, maxNumber);
            } while ((number % 2 == 0) != true);

            return number;
        }
    }
}
