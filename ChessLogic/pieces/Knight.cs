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
        public override List<Point> PossibleMoves(bool king = true)
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

            return tmp;
        }
    }
}
