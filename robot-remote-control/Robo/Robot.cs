namespace Robo
{
    public class Robot
    {
        public static int Count = 0;
        
        private Point _location;
        private string _label;
        
        public Point Location { get; set; }
        public string Label { get; set; }

        public Robot()
        {
            Count++;
            Label = $"robot{Count}";
        }

        public override string ToString()
        {
            return Label;
        }
    }
}