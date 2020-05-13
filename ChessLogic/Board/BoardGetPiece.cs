using System;
using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// It checks if there's a fiddle on the given position
        /// </summary>
        /// <param name="position">position to check</param>
        /// <param name="color">the colour of the piece on the given position</param>
        /// <param name="pieceTyp">type of piece on the given position</param>
        public bool TryGetPieceNameColorAtPosition(Point position, out Side color, out Pieces pieceTyp)
        {
            //default
            color = Side.White;
            pieceTyp = Pieces.NULL;
            foreach (Piece piece in pieceList)
            {
                if (piece.Position == position)
                {
                    color = piece.Color;
                    pieceTyp = piece.PieceName;
                    return true;
                }
            }
            return false;
        }

        public bool EnemyPosition(Point position)
        {
            foreach (Piece piece in CurrentlyNotPlayingPieces)
                if (piece.Position == position)
                    return true;

            return false;
        }

        public bool AllyPosition(Point position)
        {
            foreach (Piece piece in CurrentlyPlayingPieces)
                if (piece.Position == position)
                    return true;

            return false;
        }

        public bool RockAtPosition(Point position, out Piece rock)
        {
            rock = null;
            foreach (Piece piece in pieceList)
            {
                if (piece.Position == position)
                {
                    if (piece.PieceName == Pieces.Rock && piece.FirtTour)
                    {
                        rock = piece;
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
    }
}
