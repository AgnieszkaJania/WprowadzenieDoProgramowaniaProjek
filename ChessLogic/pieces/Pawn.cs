using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    class Pawn : Piece
    {
        public Pawn(Point coords, Game board, bool color, bool firstTour = true) : base(coords, board, color,firstTour)
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
                if(!other.TryGetPiece(position + new Point(0, 2*Direction), out bool c2, out string p2) && firstTour)
                {
                    tmp.Add(position + new Point(0, 2*Direction));
                }
            }

            return tmp;
        }
    }
}
