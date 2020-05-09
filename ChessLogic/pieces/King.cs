using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ChessLogic
{
    class King : Piece
    {
        bool FirstTour;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">piece startcoords</param>
        /// <param name="pieces">list of other pieces</param>
        /// <param name="color">piece color</param>
        public King(Point coords, Game board, bool color) : base(coords, board, color)
        {
            pieceName = "King";
            FirstTour = true;
        }
        /// <summary>
        /// return list of possible moves
        /// </summary>
        /// <returns></returns>
        public override List<Point> PossibleMoves(bool king = true)
        {
            List<Point> tmp = new List<Point>();
            //check enemi moves
            List<Point> enemyMoves = new List<Point>();
            if (king)
                enemyMoves = other.AllMoves(!color);

            //check all moves around king
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    //excludes the possibility of making an empty move
                    if (!(i == 0 && j == 0))
                    {
                        //Check if the ally is blocking the road
                        if (!other.CheckIfAlly(position + new Point(i, j), color) || !king)
                        {
                            //check if the king doesn't want to come under the beating
                            if (!enemyMoves.Contains(position + new Point(i, j)) || !king)
                            {
                                //add possible
                                tmp.Add(position + new Point(i, j));
                            }
                        }
                    }
                }
            }

            if (FirstTour && king)
            {
                List<Piece> rocks = other.GetAllPieces("Rock", color);

                if (!other.CheckIfPiece(position + new Point(1, 0), out bool b1))
                {
                    if (!other.CheckIfPiece(position + new Point(2, 0), out bool b2))
                    {
                        foreach (Piece rock in rocks)
                        {
                            if (rock.AtPosition(position + new Point(3, 0)))
                            {
                                if (((Rock)(rock)).FirstTour)
                                {
                                    tmp.Add(position + new Point(2, 0));
                                    tmp.Add(position + new Point(3, 0));
                                }
                            }
                        }
                    }
                }

                if (!other.CheckIfPiece(position + new Point(-1, 0), out bool b3))
                {
                    if (!other.CheckIfPiece(position + new Point(-2, 0), out bool b4))
                    {
                        if (!other.CheckIfPiece(position + new Point(-3, 0), out bool b5))
                        {
                            foreach (Piece rock in rocks)
                            {
                                if (rock.AtPosition(position + new Point(-4, 0)))
                                {
                                    if (((Rock)(rock)).FirstTour)
                                    {
                                        tmp.Add(position + new Point(-2, 0));
                                        tmp.Add(position + new Point(-3, 0));
                                        tmp.Add(position + new Point(-4, 0));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return tmp;
        }
        public override bool TryMakeMove(Point coords)
        {
            if (PossibleMoves().Contains(coords))
            {
                Point oldPosition = position;
                FirstTour = false;
                position = coords;

                if ((oldPosition - position).x >= 2)
                {
                    position = oldPosition - new Point(2, 0);
                    List<Piece> rocks = other.GetAllPieces("Rock", color);
                    foreach (Piece rock in rocks)
                    {
                        if (rock.AtPosition(position - new Point(2, 0)))
                        {
                            rock.position = position - new Point(1, 0);
                        }
                    }
                }
                else if ((oldPosition - position).x <= -2)
                {
                    position = oldPosition + new Point(2, 0);
                    List<Piece> rocks = other.GetAllPieces("Rock", color);
                    foreach (Piece rock in rocks)
                    {
                        if (rock.AtPosition(position + new Point(1, 0)))
                        {
                            rock.position = position - new Point(1, 0);
                        }
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
