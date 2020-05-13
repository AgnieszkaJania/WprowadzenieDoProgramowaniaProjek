using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    public partial class Point
    {
        /// <summary>
        /// Changes the point content
        /// </summary>
        /// <param name="x">X coords</param>
        /// <param name="y">Y coords</param>
        public void Change(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        /// <summary>
        /// Changes the point content
        /// </summary>
        /// <param name="point">Point coords</param>
        public void Change(Point point)
        {
            Change(point.x, point.y);
        }
    }
}
