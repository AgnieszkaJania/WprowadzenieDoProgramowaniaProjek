using System.Collections.Generic;

namespace ChessLogic
{
    abstract class Piece
    {
        //position on board
        protected Point position;
        //list of other Piece on board
        protected Game other;
        //pieces data
        protected string pieceName;
        protected bool color;
        //get piece data
        public string PieceName { get => pieceName; }
        public bool Color { get => color; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">piece startcoords</param>
        /// <param name="pieces">list of other pieces</param>
        /// <param name="color">piece color</param>
        protected Piece(Point coords, Game pieces, bool color)
        {
            position = coords;
            other = pieces;
            this.color = color;
        }
        /// <summary>
        /// return list of possible moves
        /// </summary>
        /// <returns></returns>
        public abstract List<Point> PossibleMoves(bool king = true);
        /// <summary>
        /// Makes a move
        /// </summary>
        /// <param name="coords">coords where piece have to go</param>
        /// <returns>true if successful</returns>
        public bool TryMakeMove(Point coords)
        {
            if (PossibleMoves().Contains(coords))
            {
                position = coords;
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// checks if the figure is on the specified cord
        /// </summary>
        /// <param name="p">Cord</param>
        public bool AtPosition(Point p)
        {
            if (p == position)
                return true;
            else
                return false;
        }
    }
}