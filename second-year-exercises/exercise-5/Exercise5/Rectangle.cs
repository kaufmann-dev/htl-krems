using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public class Rectangle
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public Rectangle(int length, int width)
        {
            if (length < 0)
            {
                throw new Exception("Length value not valid!");
            }
            if (width < 0)
            {
                throw new Exception("Width value not valid!");
            }
            Length = length;
            Width = width;
        }
        public string Info()
        {
            bool isSquare = IsSquare();
            if (isSquare == true)
            {
                return $"Length: {Length}\nWidth: {Width}\nIs a square!";
            }
            return $"Length: {Length}\nWidth: {Width}\nIs  not a square!";
        }
        public bool IsSquare()
        {
            if (Width == Length)
            {
                return true;
            }
            return false;
        }
    }
}
