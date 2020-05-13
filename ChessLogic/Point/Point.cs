using System;

namespace ChessLogic
{
    public partial class Point
    {
        //Stored coords
        public int x;
        public int y;
        /// <summary>
        /// Return coord sum of coordinates
        /// </summary>
        public int XaddY { get => x + y; }
        /// <summary>
        /// Create new point
        /// </summary>
        /// <param name="x">co-ordinate X</param>
        /// <param name="y">co-ordinate Y</param>
        public Point(int x, int y)
        {
            //assigning values ​​to variables
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Create new point
        /// </summary>
        /// <param name="point">another point</param>
        public Point(Point point)
        {
            //assigning values ​​to variables
            this.x = point.x;
            this.y = point.y;
        }
        /// <summary>
        /// Generate hash code
        /// </summary>
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
        /// <summary>
        /// Converts a point to string
        /// </summary>
        public override string ToString()
        {
            return $"{x} {y}";
        }
    }
}
