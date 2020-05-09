using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic.pieces
{
    class Rock : Piece
    {
        public Rock(Point coords, Game board, bool color) : base(coords, board, color)
        {
            pieceName = "Rock";
        }

        public override List<Point> PossibleMoves(bool king = true)
        {
            List<Point> tmp = new List<Point>();

            bool t = true, b = true, l = true, r = true;

            for (int i = 1; i < 8; i++)
            {
                if (!(t || b || l || r))
                    return tmp;

                //check top
                if (t)
                {
                    if (other.CheckIfPiece(position + new Point(0, i), out bool outColor))
                    {
                        if (outColor != color)
                        {
                            tmp.Add(position + new Point(0, i));
                        }
                        t = false;
                    }
                    else
                    {
                        tmp.Add(position + new Point(0, i));
                    }
                }
                //check bottom
                if (b)
                {
                    if (other.CheckIfPiece(position + new Point(0, -i), out bool outColor))
                    {
                        if (outColor != color)
                        {
                            tmp.Add(position + new Point(0, -i));
                        }
                        b = false;
                    }
                    else
                    {
                        tmp.Add(position + new Point(0, -i));
                    }
                }
                //check right
                if (r)
                {
                    if (other.CheckIfPiece(position + new Point(i, 0), out bool outColor))
                    {
                        if (outColor != color)
                        {
                            tmp.Add(position + new Point(i, 0));
                        }
                        r = false;
                    }
                    else
                    {
                        tmp.Add(position + new Point(i, 0));
                    }
                }
                //check left
                if (l)
                {
                    if (other.CheckIfPiece(position + new Point(-i, 0), out bool outColor))
                    {
                        if (outColor != color)
                        {
                            tmp.Add(position + new Point(-i, 0));
                        }
                        l = false;
                    }
                    else
                    {
                        tmp.Add(position + new Point(-i, 0));
                    }
                }
            }

            return tmp;
        }
    }
}
