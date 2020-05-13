using System.Collections.Generic;

namespace ChessLogic
{
    public class Rock : Piece
    {
        /// <summary>
        /// creating a new piece rock
        /// </summary>
        /// <param name="position">Started position</param>
        /// <param name="board">The board on which the piece is located</param>
        /// <param name="color">Color of piece</param>
        /// <param name="firstTour">If the piece has already made a move</param>
        /// <param name="move">Informs if the piece has already made a move</param>
        public Rock(Point position, Board board, Board.Side color, bool firstTour = true, int move = -1) : base(position, board, color, firstTour, move)
        {
            pieceName = Board.Pieces.Rock;
        }
        /// <summary>
        /// Creates a list of possible moves
        /// </summary>
        protected override List<Point> Moves()
        {
            //list moves
            var xRay = new List<Point>();

            bool down = true,
                right = true,
                top = true,
                left = true;

            //check all straight
            for (int i = 1; i < 8; i++)
            {
                //down
                if (down)
                {
                    Point tmp = position + new Point(0, i);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            xRay.Add(tmp);
                        down = false;
                    }
                    else if (tmp.Between(7))
                        xRay.Add(tmp);
                    else
                        down = false;
                }
                //right
                if (right)
                {
                    Point tmp = position + new Point(i, 0);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            xRay.Add(tmp);
                        right = false;
                    }
                    else if (tmp.Between(7))
                        xRay.Add(tmp);
                    else
                        right = false;
                }
                //top
                if (top)
                {
                    Point tmp = position + new Point(0, -i);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            xRay.Add(tmp);
                        top = false;
                    }
                    else if (tmp.Between(7))
                        xRay.Add(tmp);
                    else
                        top = false;
                }
                //left
                if (left)
                {
                    Point tmp = position + new Point(-i, 0);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            xRay.Add(tmp);
                        left = false;
                    }
                    else if (tmp.Between(7))
                        xRay.Add(tmp);
                    else
                        left = false;
                }
            }

            return xRay;
        }
    }
}
