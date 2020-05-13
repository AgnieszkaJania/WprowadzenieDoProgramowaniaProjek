namespace ChessLogic
{
    public partial class Point
    {
        /// <summary>
        /// Checks if two points have the same coordinates
        /// </summary>
        /// <param name="obj">A point to check</param>
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
        public static bool operator ==(Point point1, Point point2)
        {
            return (point1.Equals(point2));
        }
        /// <summary>
        /// Checks if two points have different coordinates
        /// </summary>
        /// <param name="point1">A first point to check</param>
        /// <param name="point2">A secound point to check</param>
        public static bool operator !=(Point point1, Point point2)
        {
            return (!point1.Equals(point2));
        }
        /// <summary>
        /// Subtracts the coordinates of the first point to the second
        /// </summary>
        /// <param name="point1">A first point to subtracts</param>
        /// <param name="point2">A secound point to subtracts</param>
        public static Point operator -(Point point1, Point point2)
        {
            return new Point(point1.x - point2.x, point1.y - point2.y);
        }
        /// <summary>
        /// Adds the coordinates of the first point to the second
        /// </summary>
        /// <param name="point1">A first point to add</param>
        /// <param name="point2">A secound point to add</param>
        public static Point operator +(Point point1, Point point2)
        {
            return new Point(point1.x + point2.x, point1.y + point2.y);
        }
    }
}
