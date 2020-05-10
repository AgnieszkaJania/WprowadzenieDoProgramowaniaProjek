using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ChessLogic
{
    class Knight : Piece
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">Postion of piece</param>
        /// <param name="board">the board on which the piece is located</param>
        /// <param name="color">color of piece</param>
        /// <param name="firstTour">informs if the piece has already made a move</param>
        public Knight(Point coords, Board board, bool color, bool firstTour = true, int move = -1) : base(coords, board, color, firstTour, move)
        {
            pieceName = "Knight";
        }
        /// <summary>
        /// Returns a list of possible moves
        /// </summary>
        protected override List<Point> Moves(bool check = true)
        {
            //list of possible moves
            List<Point> moves = new List<Point>();

            //check all L - shaped lines
            {//up right
                Point shift = position + new Point(1, -2);
                if (board.TryGetPieceNameColorAtPosition(shift, out string _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                }
            }
            {//up left
                Point shift = position + new Point(-1, -2);
                if (board.TryGetPieceNameColorAtPosition(shift, out string _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                }
            }
            {//left up
                Point shift = position + new Point(-2, -1);
                if (board.TryGetPieceNameColorAtPosition(shift, out string _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                }
            }
            {//left down
                Point shift = position + new Point(-2, 1);
                if (board.TryGetPieceNameColorAtPosition(shift, out string _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                }
            }
            {//down left
                Point shift = position + new Point(-1, 2);
                if (board.TryGetPieceNameColorAtPosition(shift, out string _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                }
            }
            {//down right
                Point shift = position + new Point(1, 2);
                if (board.TryGetPieceNameColorAtPosition(shift, out string _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                }
            }
            {//right down
                Point shift = position + new Point(2, 1);
                if (board.TryGetPieceNameColorAtPosition(shift, out string _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
                }
            }
            {//right up
                Point shift = position + new Point(2, -1);
                if (board.TryGetPieceNameColorAtPosition(shift, out string _, out bool color))
                {
                    if (color != this.color)
                        moves.Add(shift);
                }
                else
                {
                    if (shift.Between(7))
                        moves.Add(shift);
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
