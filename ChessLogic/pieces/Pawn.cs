using System;
using System.Collections.Generic;

namespace ChessLogic
{
    class Pawn : Piece
    {
        //direction of movement of the pawns
        protected int Direction { get { return (color) ? 1 : -1; } }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">Postion of piece</param>
        /// <param name="board">the board on which the piece is located</param>
        /// <param name="color">color of piece</param>
        /// <param name="firstTour">informs if the piece has already made a move</param>
        public Pawn(Point coords, Board board, bool color, bool firstTour = true, int move = -1) : base(coords, board, color, firstTour, move)
        {
            pieceName = "Pawn";
        }
        /// <summary>
        /// Returns a list of possible moves
        /// </summary>
        protected override List<Point> Moves(bool check = true)
        {
            //list of possible moves
            List<Point> moves = new List<Point>();

            {//check straight line
                Point shift = position + new Point(0, Direction);
                if (!board.TryGetPieceNameColorAtPosition(shift, out string name1, out bool color1))
                {
                    //single move
                    if (shift.Between(7))
                    {
                        moves.Add(shift);
                    }
                    //double move
                    if(firstTour)
                    {
                        shift = shift + new Point(0, Direction);
                        if (!board.TryGetPieceNameColorAtPosition(shift, out string name2, out bool color2))
                        {
                            if (shift.Between(7))
                            {
                                moves.Add(shift);
                            }
                        }
                    }
                }
            }
            {//check for possible beats
                Point shift = position + new Point(1, Direction);
                if (board.TryGetPieceNameColorAtPosition(shift, out string name1, out bool color1))
                {
                    if(color1!=color)
                        moves.Add(shift);
                }
                shift = position + new Point(-1, Direction);
                if (board.TryGetPieceNameColorAtPosition(shift, out string name2, out bool color2))
                {
                    if (color2 != color)
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
