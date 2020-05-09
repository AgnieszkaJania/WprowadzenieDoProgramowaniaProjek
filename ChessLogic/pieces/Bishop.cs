using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    class Bishop : Piece
    {
        public Bishop(Point coords, Game board, bool color,bool firstTour = true) : base(coords, board, color,firstTour)
        {
            pieceName = "Bishop";
        }

        public override List<Point> PossibleMoves(bool check=true)
        {
            List<Point> tmp = new List<Point>();

            bool tl = true, tr = true, bl = true, br = true;

            for (int i = 1; i < 8; i++)
            {
                if (!(tl || tr || bl || br))
                    return tmp;

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
