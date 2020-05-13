using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// Piece colors
        /// </summary>
        public enum Side
        {
            White,
            Black
        }
        /// <summary>
        /// List of pieces
        /// </summary>
        public enum Pieces
        {
            King,
            Knight,
            Pawn,
            Queen,
            Rock,
            Bishop,
            NULL
        }
        public enum Status
        {
            Game,
            Mat,
            Pat
        }
        public enum Mode
        {
            Normal,
            Test
        }
        /// <summary>
        /// Actual board mode
        /// </summary>
        public Mode mode = Mode.Normal;
        /// <summary>
        /// The site that is now playing
        /// </summary>
        Side move;
        /// <summary>
        /// List of piece on the table
        /// </summary>
        List<Piece> pieceList = new List<Piece>();
        /// <summary>
        /// List of black piece on the table
        /// </summary>
        List<Piece> blackChessPieces = new List<Piece>();
        /// <summary>
        /// List of white piece on the table
        /// </summary>
        List<Piece> whiteChessPieces = new List<Piece>();
        /// <summary>
        /// List of currently playing pieces
        /// </summary>
        List<Piece> CurrentlyPlayingPieces { get => (move == Side.Black) ? blackChessPieces : whiteChessPieces; }
        /// <summary>
        /// List of currently not playing pieces
        /// </summary>
        List<Piece> CurrentlyNotPlayingPieces { get => (move == Side.Black) ? whiteChessPieces : blackChessPieces; }
        /// <summary>
        /// currently playing king
        /// </summary>
        King currentlyNotPlayingKing { get => (move == Side.Black) ? whiteKing : blackKing; }
        /// <summary>
        /// white king
        /// </summary>
        King whiteKing;
        /// <summary>
        /// black king
        /// </summary>
        King blackKing;
        /// <summary>
        /// List of moves made
        /// </summary>
        public List<KeyValuePair<Point, Point>> movesMade = new List<KeyValuePair<Point, Point>>();
        /// <summary>
        /// function to select pawn promotion
        /// </summary>
        Func<Pieces> pawnPromotionSelect;
    }
}
