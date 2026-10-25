namespace TheDuckSimulator
{
    public class HonkAdapter : IQuackable
    {
        private IHonkable _honkable;

        public HonkAdapter(IHonkable honkable)
        {
            _honkable = honkable;
        }
        public void Quack()
        {
            _honkable.Honk();
        }
    }
}