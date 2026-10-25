using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    public class Triangle
    {
        public float A { get; set; }
        public float B { get; set; }
        public float C { get; set; }
        public Triangle(float a, float b, float c)
        {
            if (a + b <= c || a + c <= b || b + c <= a)
            {
                throw new Exception("The A, B and C values do not represent a triangle!");
            }
            A = a;
            B = b;
            C = c;
        }
        public string Info()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append($"A value: {A}\nB value: {B}\nC value: {C}");
            if (IsPerpendicular() == true)
            {
                builder.Append("\nThe triangle is perpendicular!");
            }
            if (IsEquilateral() == true)
            {
                builder.Append("\nThe triangle is equilateral!");
            }
            if (IsIsoscele() == true)
            {
                builder.Append("\nThe triangle is isoscele!");
            }
            return builder.ToString();
        }
        public bool IsPerpendicular()
        {
            if (A * A + B * B == C * C || A * A + C * C == B * B || B * B + C * C == A * A)
            {
                return true;
            }
            return false;
        }
        public bool IsEquilateral()
        {
            if (A == B || A == C || B == C)
            {
                return true;
            }
            return false;
        }
        public bool IsIsoscele()
        {
            if (A == B && A == C && B == C)
            {
                return true;
            }
            return false;
        }
    }
}
