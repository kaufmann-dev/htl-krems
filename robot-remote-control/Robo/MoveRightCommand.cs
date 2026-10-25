namespace Robo
{
    public class MoveRightCommand : ACommand
    {
        public MoveRightCommand(Robot robot) : base(robot)
        {
        }

        public override void Process()
        {
            Robot.Location.X += 1;
            // log
        }

        public override void Undo()
        {
            Robot.Location.X -= 1;
            // log
        }
    }
}