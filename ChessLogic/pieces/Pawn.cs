using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic.pieces
{
    class Pawn : Piece
    {
        public Pawn(Point coords, Game board, bool color) : base(coords, board, color)
        {
            pieceName = "Pawn";
        }

        public override List<Point> PossibleMoves(bool king = true)
        {
            List<Point> tmp = new List<Point>();

            if (other.CheckIfEnemy(position + new Point(1, Direction), color) || !king)
            {
                tmp.Add(position + new Point(1, Direction));
            }
            if (other.CheckIfEnemy(position + new Point(-1, Direction), color) || !king)
            {
                tmp.Add(position + new Point(-1, Direction));
            }
            if (!other.TryGetPiece(position + new Point(0, Direction), out bool c, out string p) && king)
            {
                tmp.Add(position + new Point(0, Direction));
            }

            return tmp;
        }
    }
}
