using System;
using System.Collections.Generic;

namespace TheDuckSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            List<IQuackable> quackList = new List<IQuackable>();
            quackList.Add(new RedHeadDuck());
            quackList.Add(new RubberDuck());
            quackList.Add(new RubberDuck());
            quackList.Add(new MallardDuck());
            quackList.Add(new HonkAdapter(new Goose()));
            
            DuckSimulator duckSimulator = new DuckSimulator();

            foreach (IQuackable quackable in quackList)
            {
                duckSimulator.Simulate(quackable);
            }
        }
    }
}