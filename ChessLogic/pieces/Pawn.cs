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

        public override List<Point> PossibleMoves(bool check = true)
        {
            List<Point> tmp = new List<Point>();

            if (other.CheckIfEnemy(position + new Point(1, Direction), color) || !check)
            {
                tmp.Add(position + new Point(1, Direction));
            }
            if (other.CheckIfEnemy(position + new Point(-1, Direction), color) || !check)
            {
                tmp.Add(position + new Point(-1, Direction));
            }
            if (!other.TryGetPiece(position + new Point(0, Direction), out bool c, out string p))
            {
                tmp.Add(position + new Point(0, Direction));
                if(!other.TryGetPiece(position + new Point(0, 2*Direction), out bool c2, out string p2) && firstTour)
                {
                    tmp.Add(position + new Point(0, 2*Direction));
                }
            }

            if (check)
            {
                for (int i = tmp.Count - 1; i >= 0; i--)
                {
                    if (Check(tmp[i]))
                    {
                        tmp.Remove(tmp[i]);
                    }
                }
            }

            return tmp;
        }
    }
}
