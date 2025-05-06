using Ugadaika.Domain.Contracts;
using Ugadaika.Domain.Interfaces;

namespace Ugadaika
{
    internal class Program
    {
        static void Main(string[] args)
        {

            INumberGenerator generator = new NumberGenerator();

            var game = new UgadaikaGame(generator, 1, 10);

            game.Play();
        }
    }
}
