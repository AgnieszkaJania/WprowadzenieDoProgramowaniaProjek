using System;
using System.Collections.Generic;

namespace ChessLogic
{
    public partial class Board
    {
        //Means which side is currently moving
        //true - black
        //false - white
        bool move = false;
        //List of all chessboard pieces
        List<Piece> piecesList = new List<Piece>();
        //list of moves made
        public List<KeyValuePair<Point, Point>> movesMade = new List<KeyValuePair<Point, Point>>();
        //operating mode
        //true - normal
        //false - as a simulation
        bool mode;
        /// <summary>
        /// return operationg mode
        /// </summary>
        public bool Mode { get => mode; }
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
        /// <summary>
        /// Constructor
        /// </summary>
        public Board(bool mode = true)
        {
            this.mode = mode;
            if(mode)
            {
                Init();
            }
        }
    }
}
