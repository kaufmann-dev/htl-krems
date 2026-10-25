namespace Robo
{
    public class MoveUpCommand : ACommand
    {
        public MoveUpCommand(Robot robot) : base(robot)
        {
        }

        public override void Process()
        {
            Robot.Location.Y -= 1;
            // log
        }

        public override void Undo()
        {
            Robot.Location.Y += 1;
            // log
        }
    }
}