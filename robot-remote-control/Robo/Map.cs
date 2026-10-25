using System.Collections.Generic;
using System.Text;

namespace Robo
{
    public class Map
    {
        private static Map map = new Map();

        private Point[,] _content = new Point[16, 16];
        private List<Robot> _robots = new List<Robot>();
    
        public static Map GetInstance()
        {
            return map;
        }

        private Map()
        {
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    _content[j, i] = new Point(j, i);
                }
            }
        }

        public bool IsPointLegal(Point p)
        {
            if (_content[p.X, p.Y] == null)
            {
                return true;
            }

            return false;
        }

        public bool IsMoveLegal(Robot robot, EDirectionType directionType)
        {
            switch (directionType)
            {
                case EDirectionType.NORTH:
                    if (IsPointLegal(_content[robot.Location.X, robot.Location.Y - 1]))
                    {
                        return true;
                    }
                    break;
                case EDirectionType.EAST:
                    if (IsPointLegal(_content[robot.Location.X + 1, robot.Location.Y]))
                    {
                        return true;
                    }
                    break;
                case EDirectionType.SOUTH:
                    if (IsPointLegal(_content[robot.Location.X, robot.Location.Y + 1]))
                    {
                        return true;
                    }
                    break;
                case EDirectionType.WEST:
                    if (IsPointLegal(_content[robot.Location.X - 1, robot.Location.Y]))
                    {
                        return true;
                    }
                    break;
            }

            return false;
        }

        private Point GetEmptyLocation()
        {
            foreach (Point c in _content)
            {
                if (c != null)
                {
                    return c;
                }
            }

            return null;
        }

        public bool Register(Robot robot)
        {
            if (_robots.Contains(robot) == false)
            {
                Point x = GetEmptyLocation();
                if (x != null)
                {
                    robot.Location = x;
                    _robots.Add(robot);
                    return true;
                }
            }

            return false;
        }

        private List<Point> GenerateRobotLocationList()
        {
            List<Point> exde = new List<Point>();
            
            foreach (Robot rob in _robots)
            {
                exde.Add(rob.Location);
            }

            return exde;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _content.GetLength(1); i++)
            {
                for (int j = 0; j < _content.GetLength(0); j++)
                {
                    if (_content[j,i] != null)
                    {
                        sb.Append("r");
                    }
                    else
                    {
                        sb.Append("o");
                    }
                }

                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
}