using System;

namespace Shogun
{
    public class TestClassVector
    {
        private int x;
        private int y;

        public TestClassVector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X => x;

        public int Y => y;
    }
}