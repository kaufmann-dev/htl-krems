using System;

namespace TheDuckSimulator
{
    public class MallardDuck : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("quack quack");
        }
    }
}