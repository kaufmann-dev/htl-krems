namespace TheDuckSimulator
{
    public class DuckSimulator
    {
        public void Simulate(IQuackable quackable)
        {
            quackable.Quack();
        }
    }
}