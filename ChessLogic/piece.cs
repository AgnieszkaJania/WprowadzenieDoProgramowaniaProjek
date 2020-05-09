using System.Collections.Generic;
using System.Text;

namespace ChessLogic
{
    public abstract class Piece
    {
        public bool firstTour;
        //position on board
        public Point position;
        //list of other Piece on board
        protected Game other;
        //pieces data
        protected string pieceName;
        protected bool color;
        //get piece data
        public string PieceName { get => pieceName; }
        public bool Color { get => color; }
        public int Direction
        {
            get
            {
                if (color)
                    return -1;
                else
                    return 1;
            }
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">piece startcoords</param>
        /// <param name="pieces">list of other pieces</param>
        /// <param name="color">piece color</param>
        protected Piece(Point coords, Game pieces, bool color, bool firstTour = true)
        {
            position = coords;
            other = pieces;
            this.color = color;
            this.firstTour = firstTour;
        }
        /// <summary>
        /// return list of possible moves
        /// </summary>
        /// <returns></returns>
        public abstract List<Point> PossibleMoves(bool check = true);
        /// <summary>
        /// Makes a move
        /// </summary>
        /// <param name="coords">coords where piece have to go</param>
        /// <returns>true if successful</returns>
        public virtual bool TryMakeMove(Point coords)
        {
            if (PossibleMoves(other.check).Contains(coords))
            {
                firstTour = false;
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

        protected bool Check(Point coords)
        {
            Game simulate = other.Copy();
            simulate.check = false;
            simulate.TryMakeMove(position, coords);

            if (simulate.IsCheck(color))
            {
                return true;
            }
            return false;
        }
    }
}