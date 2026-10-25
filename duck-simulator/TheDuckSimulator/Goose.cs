using System;

namespace TheDuckSimulator
{
    public class Goose : IHonkable
    {
        public void Honk()
        {
            Console.WriteLine("honk");
        }
    }
}