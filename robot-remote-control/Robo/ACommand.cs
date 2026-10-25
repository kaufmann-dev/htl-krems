namespace Robo
{
    public abstract class ACommand
    {
        protected Robot _robot;
        
        public Robot Robot { get; set; }

        public ACommand(Robot robot)
        {
            this.Robot = robot;
        }

        public abstract void Process();

        public abstract void Undo();
    }
}