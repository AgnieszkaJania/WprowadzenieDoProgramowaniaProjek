using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// Checks if there is a piece on the given position
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <param name="pieceName">return pieceName</param>
        /// <param name="color">return pieceColor</param>
        /// <returns>True if found</returns>
        public bool TryGetPieceNameColorAtPosition(Point position, out string pieceName, out bool color)
        {
            //set default values
            pieceName = "";
            color = false;
            //for all piece
            foreach (Piece piece in piecesList)
            {
                //check if his position matches that given
                if (piece.position == position)
                {
                    //complete the data and finish the work
                    color = piece.Color;
                    pieceName = piece.PieceName;
                    return true;
                }
            }
            //if not found return false
            return false;
        }
    }
}
