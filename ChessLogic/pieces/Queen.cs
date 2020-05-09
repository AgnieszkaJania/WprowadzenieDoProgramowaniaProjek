using System.Collections.Generic;

namespace ChessLogic
{
    class Queen : Piece
    {
        public Queen(Point coords, Game board, bool color, bool firstTour = true) : base(coords, board, color, firstTour)
        {
            pieceName = "Queen";
        }

        public override List<Point> PossibleMoves(bool check = true)
        {
            List<Point> tmp = new List<Point>();

            bool t = true, b = true, l = true, r = true,
                tl = true, tr = true, bl = true, br = true;

            for (int i = 1; i < 8; i++)
            {
                if (!(t || b || l || r || tl || tr || bl || br))
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
                if (tl)
                {
                    if (other.CheckIfPiece(position + new Point(i, i), out bool outColor))
                    {
                        if (outColor != color)
                        {
                            tmp.Add(position + new Point(i, i));
                        }
                        tl = false;
                    }
                    else
                    {
                        tmp.Add(position + new Point(i, i));
                    }
                }
                if (tr)
                {
                    if (other.CheckIfPiece(position + new Point(-i, i), out bool outColor))
                    {
                        if (outColor != color)
                        {
                            tmp.Add(position + new Point(-i, i));
                        }
                        tr = false;
                    }
                    else
                    {
                        tmp.Add(position + new Point(-i, i));
                    }
                }
                if (bl)
                {
                    if (other.CheckIfPiece(position + new Point(i, -i), out bool outColor))
                    {
                        if (outColor != color)
                        {
                            tmp.Add(position + new Point(i, -i));
                        }
                        bl = false;
                    }
                    else
                    {
                        tmp.Add(position + new Point(i, -i));
                    }
                }
                if (br)
                {
                    if (other.CheckIfPiece(position + new Point(-i, -i), out bool outColor))
                    {
                        if (outColor != color)
                        {
                            tmp.Add(position + new Point(-i, -i));
                        }
                        br = false;
                    }
                    else
                    {
                        tmp.Add(position + new Point(-i, -i));
                    }
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
