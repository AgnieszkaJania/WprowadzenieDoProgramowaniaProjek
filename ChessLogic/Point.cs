using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ChessLogic
{
    /// <summary>
    /// stored cooord X and Y
    /// </summary>
    public partial class Point
    {
        public int x;
        public int y;

        public int AddXY { get => x + y; }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool check(int Max, int Min = 0)
        {
            if (x > Max || y > Max)
                return false;
            if (x < Min || y < Min)
                return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   x == point.x &&
                   y == point.y;
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.Equals(p2));
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return (!p1.Equals(p2));
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
