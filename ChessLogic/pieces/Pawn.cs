using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic.pieces
{
    class Pawn:Piece
    {
        public Pawn(Point coords, Game board, bool color) : base(coords, board, color)
        {
            pieceName = "Pawn";
        }

        public override List<Point> PossibleMoves(bool king = true)
        {
            return new List<Point>();
            throw new NotImplementedException();
        }
    }
}
