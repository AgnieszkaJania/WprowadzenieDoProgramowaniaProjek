using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// Checks if there is a piece at the given position
        /// </summary>
        /// <param name="position">position to check</param>
        /// <param name="moves">Returns the possible moves of the piece</param>
        /// <returns>good truth if the piece exists</returns>
        public bool TryGetMoves(Point position, out List<Point> moves)
        {
            moves = new List<Point>();

            foreach (Piece piece in piecesList)
            {
                if (piece.position == position)
                {//find the piece
                    if (piece.Color == move)
                    {//check if he can make a move
                        moves = piece.PossibleMoves;
                        return true;
                    }
                    else
                    {//if can't
                        return false;
                    }
                }
            }
            //if not found
            return false;
        }
        /// <summary>
        /// Checks whether you can move the piece to the given coordinates
        /// </summary>
        /// <param name="position">piece coords</param>
        /// <param name="coords">place to move</param>
        /// <returns>returns true if the action was successful</returns>
        public bool TryMakeMove(Point position, Point coords)
        {
            foreach (Piece piece in piecesList)
            {
                //find piece
                if (piece.position == position)
                {
                    //check if he can make a move
                    if (piece.TryMakeMove(coords, mode) && piece.Color == move)
                    {
                        //check if he has beaten anyone
                        foreach (Piece remove in piecesList)
                        {
                            if (remove.position == coords)
                            {
                                if(remove.Color != move)
                                {
                                    //beat
                                    piecesList.Remove(remove);
                                    break;
                                }
                            }
                        }

                        //make a move
                        move = !move;
                        movesMade.Add(new KeyValuePair<Point, Point>(position, coords));

                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the king is under attack
        /// </summary>
        /// <param name="color">Color of king</param>
        /// <returns>Returns true if it is under attack</returns>
        public bool IsCheck(bool color)
        {
            //King
            Piece King = new King(new Point(-1, -1), this, color);
            //list of posible enemis moves
            List<Point> EnemyMoves = new List<Point>();
            //get them
            foreach (Piece piece in piecesList)
            {
                if (piece.Color == color)
                {
                    if (piece.PieceName == "King")
                    {
                        King = piece;
                    }
                }
                else
                {
                    foreach (Point move in piece.PossibleMoves)
                    {
                        EnemyMoves.Add(move);
                    }
                }
            }

            if (EnemyMoves.Contains(King.position))
                return true;
            return false;
        }
    }
}
