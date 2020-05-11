using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    class Bishop : Piece
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">Postion of piece</param>
        /// <param name="board">the board on which the piece is located</param>
        /// <param name="color">color of piece</param>
        /// <param name="firstTour">informs if the piece has already made a move</param>
        public Bishop(Point coords, Board board, bool color, bool firstTour = true, int move = -1) : base(coords, board, color, firstTour, move)
        {
            pieceName = "Bishop";
        }
        /// <summary>
        /// Returns a list of possible moves
        /// </summary>
        protected override List<Point> Moves(bool check = true)
        {
            //list of possible moves
            List<Point> moves = new List<Point>();

            //check all oblique lines
            //up left
            for (int i = 1; i < 8; i++)
            {

                Point shift = position + new Point(-i, -i);
                if (board.TryGetPieceNameColorAtPosition(shift, out _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                    break;
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                    else
                        break;
                }
            }
            //up right
            for (int i = 1; i < 8; i++)
            {
                Point shift = position + new Point(i, -i);
                if (board.TryGetPieceNameColorAtPosition(shift, out _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                    break;
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                    else
                        break;
                }
            }
            //down left
            for (int i = 1; i < 8; i++)
            {
                Point shift = position + new Point(-i, i);
                if (board.TryGetPieceNameColorAtPosition(shift, out _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                    break;
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                    else
                        break;
                }
            }
            //down right
            for (int i = 1; i < 8; i++)
            {
                Point shift = position + new Point(i, i);
                if (board.TryGetPieceNameColorAtPosition(shift, out _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                    break;
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                    else
                        break;
                }
            }

            //remove all life-threatening movements of the king
            if (check)
            {
                for (int i = moves.Count - 1; i >= 0; i--)
                {
                    if (Check(moves[i]))
                    {
                        moves.Remove(moves[i]);
                    }
                }
            }
            return moves;
        }
    }
}
