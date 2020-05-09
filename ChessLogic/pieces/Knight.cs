using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    class Knight : Piece
    {
        public Knight(Point coords, Game board, bool color, bool firstTour = true) : base(coords, board, color, firstTour)
        {
            pieceName = "Knight";
        }
        public override List<Point> PossibleMoves(bool check=true)
        {
            List<Point> tmp = new List<Point>();

            if (!other.CheckIfAlly(position + new Point(2, 1), color))
            {
                tmp.Add(position + new Point(2, 1));
            }
            if (!other.CheckIfAlly(position + new Point(-2, 1), color))
            {
                tmp.Add(position + new Point(-2, 1));
            }
            if (!other.CheckIfAlly(position + new Point(2, -1), color))
            {
                tmp.Add(position + new Point(2, -1));
            }
            if (!other.CheckIfAlly(position + new Point(-2, -1), color))
            {
                tmp.Add(position + new Point(-2, -1));
            }

            if (!other.CheckIfAlly(position + new Point(1, 2), color))
            {
                tmp.Add(position + new Point(1, 2));
            }
            if (!other.CheckIfAlly(position + new Point(-1, 2), color))
            {
                tmp.Add(position + new Point(-1, 2));
            }
            if (!other.CheckIfAlly(position + new Point(1, -2), color))
            {
                tmp.Add(position + new Point(1, -2));
            }
            if (!other.CheckIfAlly(position + new Point(-1, -2), color))
            {
                tmp.Add(position + new Point(-1, -2));
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
