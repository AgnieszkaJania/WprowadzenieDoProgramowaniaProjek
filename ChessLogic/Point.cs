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
        //point coords
        public int x;
        public int y;
        //return x+y;
        public int AddXY { get => x + y; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">X coord</param>
        /// <param name="y">Y coord</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Check if value is beetwen Max and Min
        /// </summary>
        /// <param name="Max">Max</param>
        /// <param name="Min">Min</param>
        /// <returns>true if coords are in the range of <Min-Max></returns>
        public bool check(int Max, int Min = 0)
        {
            if (x > Max || y > Max)
                return false;
            if (x < Min || y < Min)
                return false;
            return true;
        }
        /// <summary>
        /// Check if two points are equals
        /// </summary>
        /// <param name="obj">Object to check</param>
        /// <returns>true if they are the same</returns>
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   x == point.x &&
                   y == point.y;
        }
        /// <summary>
        /// Check if two points are equals
        /// </summary>
        /// <param name="p1">First point to check</param>
        /// <param name="p2">Secound point to check</param>
        /// <returns>true if they are the same</returns>
        public static bool operator ==(Point p1, Point p2)
        {
            return (p1.Equals(p2));
        }
        /// <summary>
        /// Check if two points are not equals
        /// </summary>
        /// <param name="p1">First point to check</param>
        /// <param name="p2">Secound point to check</param>
        /// <returns>false if they are the same</returns>
        public static bool operator !=(Point p1, Point p2)
        {
            return (!p1.Equals(p2));
        }
        /// <summary>
        /// Returns point with added coords
        /// </summary>
        /// <param name="p1">first point to add</param>
        /// <param name="p2">Secound point to add</param>
        /// <returns></returns>
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
