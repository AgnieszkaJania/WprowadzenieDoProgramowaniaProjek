namespace ChessLogic
{
    public partial class Point
    {
        /// <summary>
        /// Check if the co-ordinates are between min and max
        /// </summary>
        /// <param name="max">maximum value</param>
        /// <param name="min">minimum value</param>
        public bool Between(int max, int min = 0)
        {
            //Check co-ordinate X
            if (x > max || x < min)
                return false;
            //check co-ordinate Y
            if (y > max || y < min)
                return false;
            //if co-ordinates are between min and max return true
            return true;
        }
    }
}
