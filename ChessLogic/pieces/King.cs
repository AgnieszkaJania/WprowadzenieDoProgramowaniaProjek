using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;

namespace ChessLogic
{
    class King : Piece
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">piece startcoords</param>
        /// <param name="pieces">list of other pieces</param>
        /// <param name="color">piece color</param>
        public King(Point coords, Game board, bool color, bool firstTour = true) : base(coords, board, color, firstTour)
        {
            pieceName = "King";
        }
        /// <summary>
        /// return list of possible moves
        /// </summary>
        /// <returns></returns>
        public override List<Point> PossibleMoves(bool check = true)
        {
            var tmp = new List<Point>();

            if (firstTour)
            {
                var rocks = other.GetAllPieces("Rock", color);
                foreach (var rock in rocks)
                {
                    if (rock.firstTour)
                    {
                        int min = (rock.position.x < position.x) ? rock.position.x : position.x;
                        int max = (rock.position.x > position.x) ? rock.position.x : position.x;

                        List<Point> RememberMe = new List<Point>();
                        bool allay = false;

                        for (int i = min; i <= max + 1; i++)
                        {
                            var point = new Point(i, position.y);

                            if (other.CheckIfAlly(point, color) && point != position && point != rock.position)
                            {
                                allay = true;
                                break;
                            }

                            tmp.Add(point);
                            RememberMe.Add(point);
                        }

                        if (check)
                        {
                            for (int i = tmp.Count - 1; i >= 0; i--)
                            {
                                if (Check(tmp[i]) || allay)
                                {
                                    foreach (Point remember in RememberMe)
                                    {
                                        tmp.Remove(remember);
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (!(j == 0 && i == 0))
                    {
                        Point newPoint = position + new Point(i, j);
                        if (newPoint.check(7))
                        {
                            if (!other.CheckIfAlly(newPoint, color))
                                tmp.Add(newPoint);
                        }
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

        public override bool TryMakeMove(Point coords)
        {
            if (PossibleMoves(other.check).Contains(coords))
            {
                var tmp = position - coords;

                if (Math.Abs(tmp.x) > 1)
                {
                    var rocks = other.GetAllPieces("Rock", color);
                    foreach (var rock in rocks)
                    {
                        if (tmp.x < 0)
                        {
                            if (rock.position == new Point(7, position.y))
                            {
                                rock.position = position + new Point(1,0);
                                position = rock.position + new Point(1, 0);
                            }
                        }
                        else if(tmp.x > 0)
                        {
                            if (rock.position == new Point(0, position.y))
                            {
                                rock.position = position - new Point(1, 0);
                                position = rock.position - new Point(1, 0);
                            }
                        }
                    }
                }
                else
                {
                    position = coords;
                }

                firstTour = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
