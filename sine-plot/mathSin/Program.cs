using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mathSin
{
    class Program
    {
        static void Main(string[] args)
        {
            Point point1 = new Point();
            point1.x = 4;
            point1.y = 3;

            Point point2 = new Point();
            point2.x = 1;
            point2.y = 4;


            Point point3 = new Point();
            point3.x = 7;
            point3.y = 3;

            Console.ReadLine();
        }

        static int[] PointsToList(Point point1, Point point2, Point point3)
        {
            int[] pointList = new int[6];
            pointList[0] = point1.x;
            pointList[1] = point1.y;
            pointList[2] = point2.x;
            pointList[3] = point2.y;
            pointList[4] = point3.x;
            pointList[5] = point3.y;

            return pointList;
        }

        static void PrintList(int[] pointList)
        {
            for (int i = 0; i < pointList.Length; i++)
            {
                Console.WriteLine(pointList[i]);
            }
        }
    }
}
