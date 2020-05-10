using System;

namespace ChessLogic
{
    /// <summary>
    /// Stores coordinates X and Y and performs operations on them
    /// </summary>
    public class Point
    {
        //Stored coords
        public int x;
        public int y;
        //Return x+y;
        public int xADDy { get => x + y; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="x">co-ordinate X</param>
        /// <param name="y">co-ordinate Y</param>
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Checks if the co-ordinates are between min and max
        /// </summary>
        /// <param name="max">Maximum value</param>
        /// <param name="min">Minimum value</param>
        /// <returns>Returns true if the coordinates X and Y are between min and max closed on both sides</returns>
        public bool Between(int max, int min = 0)
        {
            //check co-ordinate X
            if (x > max || x < min)
                return false;
            //check co-ordinate X
            if (y > max || y < min)
                return false;
            //if co-ordinates are between min and max return true
            return true;
        }
        /// <summary>
        /// Checks if two points have the same coordinates
        /// </summary>
        /// <param name="obj">A point to check</param>
        /// <returns>Returns true if the coordinates are the same</returns>
        public override bool Equals(object obj)
        {
            return obj is Point point &&
                   x == point.x &&
                   y == point.y;
        }
        /// <summary>
        /// Checks if two points have the same coordinates
        /// </summary>
        /// <param name="point1">A first point to check</param>
        /// <param name="point2">A secound point to check</param>
        /// <returns>Returns true if the coordinates are the same</returns>
        public static bool operator ==(Point point1, Point point2)
        {
            return (point1.Equals(point2));
        }
        /// <summary>
        /// Checks if two points have different coordinates
        /// </summary>
        /// <param name="point1">A first point to check</param>
        /// <param name="point2">A secound point to check</param>
        /// <returns>Returns false if the coordinates are the same</returns>
        public static bool operator !=(Point point1, Point point2)
        {
            return (!point1.Equals(point2));
        }
        /// <summary>
        /// Subtracts the coordinates of the first point to the second
        /// </summary>
        /// <param name="point1">A first point to subtracts</param>
        /// <param name="point2">A secound point to subtracts</param>
        /// <returns>Returns a new point with the coordinates of the first point shifted by an opposite second point</returns>
        public static Point operator -(Point point1, Point point2)
        {
            return new Point(point1.x - point2.x, point1.y - point2.y);
        }
        /// <summary>
        /// Adds the coordinates of the first point to the second
        /// </summary>
        /// <param name="point1">A first point to add</param>
        /// <param name="point2">A secound point to add</param>
        /// <returns>Returns the new point with the first point coordinates shifted by the second point</returns>
        public static Point operator +(Point point1, Point point2)
        {
            return new Point(point1.x + point2.x, point1.y + point2.y);
        }
        /// <summary>
        /// Generate hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
        /// <summary>
        /// Converts a point to string
        /// </summary>
        /// <returns>Returns coordinates separated by a space</returns>
        public override string ToString()
        {
            return $"{x} {y}";
        }
    }
}
