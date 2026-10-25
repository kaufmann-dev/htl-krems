using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public class Box
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public int Volume { get; }
        public Box(int width, int length, int height)
        {
            if (width < 0)
            {
                throw new Exception("Width value not valid!");
            }
            if (length < 0)
            {
                throw new Exception("Length value not valid!");
            }
            if (height < 0)
            {
                throw new Exception("Height value not valid!");
            }
            Width = width;
            Length = length;
            Height = height;
            Volume = width * length * height;
        }
        public string Info()
        {
            return $"Width: {Width}\nLength: {Length}\nHeight: {Height}\nVolume: {Volume}";
        }
    }
}
