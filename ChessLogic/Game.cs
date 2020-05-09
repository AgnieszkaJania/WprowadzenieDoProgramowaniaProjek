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
                    if(p.TryMakeMove(coord))
                    {
                        
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("tu jestem");
                        return false;
                    }
                }
            }
            return false;
        }
    }
}
