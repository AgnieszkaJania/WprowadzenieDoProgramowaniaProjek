using System.Collections.Generic;

namespace ChessLogic
{
    public class Knight : Piece
    {
        /// <summary>
        /// creating a new piece knight
        /// </summary>
        /// <param name="position">Started position</param>
        /// <param name="board">The board on which the piece is located</param>
        /// <param name="color">Color of piece</param>
        /// <param name="firstTour">If the piece has already made a move</param>
        /// <param name="move">Informs if the piece has already made a move</param>
        public Knight(Point position, Board board, Board.Side color, bool firstTour = true, int move = -1) : base(position, board, color, firstTour, move)
        {
            pieceName = Board.Pieces.Knight;
        }
        /// <summary>
        /// Creates a list of possible moves
        /// </summary>
        protected override List<Point> Moves()
        {
            //list moves
            var xRay = new List<Point>();

            //right down
            {
                Point tmp = position + new Point(2, 1);
                if (!board.AllyPosition(tmp))
                    xRay.Add(tmp);
            }
            //right top
            {
                Point tmp = position + new Point(2, -1);
                if (!board.AllyPosition(tmp))
                    xRay.Add(tmp);
            }
            //top right
            {
                Point tmp = position + new Point(1, -2);
                if (!board.AllyPosition(tmp))
                    xRay.Add(tmp);
            }
            //top left
            {
                Point tmp = position + new Point(-1, -2);
                if (!board.AllyPosition(tmp))
                    xRay.Add(tmp);
            }
            //left top
            {
                Point tmp = position + new Point(-2, -1);
                if (!board.AllyPosition(tmp))
                    xRay.Add(tmp);
            }
            //left down
            {
                Point tmp = position + new Point(-2, 1);
                if (!board.AllyPosition(tmp))
                    xRay.Add(tmp);
            }
            //down left
            {
                Point tmp = position + new Point(-1, 2);
                if (!board.AllyPosition(tmp))
                    xRay.Add(tmp);
            }
            //down right
            {
                Point tmp = position + new Point(1, 2);
                if (!board.AllyPosition(tmp))
                    xRay.Add(tmp);
            }

            return xRay;
        }
    }
}
