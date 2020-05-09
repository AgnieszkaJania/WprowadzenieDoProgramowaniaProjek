using ChessLogic.pieces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessLogic
{
    public class Game
    {
        List<Piece> piecesList = new List<Piece>();
        /// <summary>
        /// Constructor
        /// </summary>
        public Game()
        {
            init();
        }
        /// <summary>
        /// Initialize game board
        /// </summary>
        void init()
        {
            //kings
            piecesList.Add(new King(new Point(4, 0), this, false));
            piecesList.Add(new King(new Point(4, 7), this, true));
            //Pawn Black
            piecesList.Add(new Pawn(new Point(0, 1), this, false));
            piecesList.Add(new Pawn(new Point(1, 1), this, false));
            piecesList.Add(new Pawn(new Point(2, 1), this, false));
            piecesList.Add(new Pawn(new Point(3, 1), this, false));
            piecesList.Add(new Pawn(new Point(4, 1), this, false));
            piecesList.Add(new Pawn(new Point(5, 1), this, false));
            piecesList.Add(new Pawn(new Point(6, 1), this, false));
            piecesList.Add(new Pawn(new Point(7, 1), this, false));
            //Pawn White
            piecesList.Add(new Pawn(new Point(0, 6), this, true));
            piecesList.Add(new Pawn(new Point(1, 6), this, true));
            piecesList.Add(new Pawn(new Point(2, 6), this, true));
            //piecesList.Add(new Pawn(new Point(3, 6), this, true));
            piecesList.Add(new Pawn(new Point(4, 5), this, false));
            //piecesList.Add(new Pawn(new Point(5, 6), this, true));
            piecesList.Add(new Pawn(new Point(6, 6), this, true));
            piecesList.Add(new Pawn(new Point(7, 6), this, true));
        }
        /// <summary>
        /// Check if occurs piece on the given coords
        /// </summary>
        /// <param name="coords">coord to check</param>
        /// <param name="color">out piece color</param>
        /// <param name="piece">out piece name</param>
        /// <returns></returns>
        public bool TryGetPiece(Point coords, out bool color, out string piece)
        {
            color = false;
            piece = "";
            foreach (Piece p in piecesList)
            {
                if (p.AtPosition(coords))
                {
                    color = p.Color;
                    piece = p.PieceName;
                    return true;
                }
            };
            return false;
        }
        /// <summary>
        /// Check if occurs piece on the given coords
        /// </summary>
        /// <param name="coord">coord to check</param>
        /// <param name="moves">out posible moves</param>
        /// <returns></returns>
        public bool TryGetMoves(Point coord, out List<Point> moves)
        {
            moves = new List<Point>();
            foreach (Piece p in piecesList)
            {
                if (p.AtPosition(coord))
                {
                    moves = p.PossibleMoves();

                    return true;
                }
            }
            return false;
        }

        public bool TryMakeMove(Point piece, Point coord)
        {
            foreach (Piece p in piecesList)
            {
                if (p.AtPosition(piece))
                {
                    if (p.TryMakeMove(coord))
                    {
                        TryBeatEnemy(coord, p.Color);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public List<Point> AllMoves(bool color)
        {
            List<Point> tmp = new List<Point>();
            foreach (Piece p in piecesList)
            {
                if (p.Color == color)
                {
                    var moves = p.PossibleMoves(false);
                    foreach (Point move in moves)
                    {
                        tmp.Add(move);
                    }
                }
            }
            return tmp;
        }

        public bool CheckIfAlly(Point Position, bool color)
        {
            foreach(Piece p in piecesList)
            {
                if(p.AtPosition(Position))
                {
                    if(p.Color==color)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public bool CheckIfEnemy(Point Position, bool color)
        {
            foreach (Piece p in piecesList)
            {
                if (p.AtPosition(Position))
                {
                    if (p.Color != color)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        void TryBeatEnemy(Point Position, bool color)
        {
            foreach (Piece p in piecesList)
            {
                if (p.AtPosition(Position))
                {
                    if (p.Color != color)
                    {
                        piecesList.Remove(p);
                        return;
                    }
                }
            }
        }
    }
}
