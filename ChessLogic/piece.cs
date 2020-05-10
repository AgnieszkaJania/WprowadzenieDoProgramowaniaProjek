using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ChessLogic
{
    abstract class Piece
    {
        //informs if the piece has already made a move
        protected bool firstTour;
        //position on the board
        public Point position;
        //color of piece
        //true - black
        //false - white
        protected bool color;
        //the board on which the piece is located
        protected Board board;
        //chessman name
        protected string pieceName;
        //calculated movements
        int move;

        //get Data
        public bool FirstTour { get => firstTour; }
        public bool Color { get => color; }
        public string PieceName { get => pieceName; }
        public int Move { get => move; }

        /// <summary>
        /// List of possible piece moves
        /// </summary>
        protected abstract List<Point> Moves(bool check = true);
        /// <summary>
        /// List of moves that can be made this turn
        /// </summary>
        List<Point> possibleMoves;
        /// <summary>
        /// List of moves that can be made this turn
        /// </summary>
        public List<Point> PossibleMoves
        {
            get
            {
                //if the list has been created just return it
                if (board.movesMade.Count == move)
                {
                    return possibleMoves;
                }
                else
                {
                    //create a list of possible moves
                    move = board.movesMade.Count;
                    possibleMoves = Moves(board.Mode);
                    return possibleMoves;
                }
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">Postion of piece</param>
        /// <param name="board">the board on which the piece is located</param>
        /// <param name="color">color of piece</param>
        /// <param name="firstTour">informs if the piece has already made a move</param>
        public Piece(Point coords, Board board, bool color, bool firstTour, int move)
        {
            possibleMoves = new List<Point>();
            position = coords;
            this.board = board;
            this.color = color;
            this.firstTour = firstTour;
            this.move = move;
        }
        /// <summary>
        /// Trying to make a move with a pawn 
        /// </summary>
        /// <param name="position">the position at which to move</param>
        /// <returns>returns true if the operation was successful</returns>
        public virtual bool TryMakeMove(Point position, bool check = true)
        {
            if(PossibleMoves.Contains(position))
            {
                firstTour = false;
                this.position = position;
                return true;
            }
            return false;
        }
        /// <summary>
        /// He checks whether moving the piece to a given position will not put the king in danger
        /// </summary>
        /// <param name="coords">Coords to move</param>
        /// <returns>returns the truth when the king is in danger</returns>
        protected bool Check(Point coords)
        {
            //create new board to simulate new tour
            Board simulate = board.Copy();
            //simulate move
            simulate.TryMakeMove(position, coords);
            //chek if king in danger
            if (simulate.IsCheck(color))
                return true;
            return false;
        }
    }
}
