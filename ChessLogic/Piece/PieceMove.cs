using System.Collections.Generic;

namespace ChessLogic
{
    public partial class Piece
    {
        /// <summary>
        /// Creates a list of possible moves
        /// </summary>
        protected virtual List<Point> Moves() => new List<Point>();
        /// <summary>
        /// The move number that was generated
        /// </summary>
        int move;
        /// <summary>
        /// Previously generated list of possible moves
        /// </summary>
        List<Point> possibleMoves;
        /// <summary>
        /// Returns a list of possible movements
        /// </summary>
        public List<Point> PossibleMove
        {
            get
            {
                if (board.movesMade.Count == move)//if it has already been generated
                    return possibleMoves;
                else
                {//if it has not already been generated
                    possibleMoves = new List<Point>();
                    //generate Pseudo-Legal Move
                    if (board.mode == Board.Mode.Normal)
                    {
                        foreach (Point move in Moves())
                        {
                            Board tmp = board.Copy();
                            tmp.TryMakeMove(position, move, out _);

                            if (!tmp.Check())
                                possibleMoves.Add(move);
                        }
                    }
                    else
                    {
                        possibleMoves = Moves();
                    }
                    move = board.movesMade.Count;
                    //cleer ilegal moves
                    return possibleMoves;
                }
            }
        }

        public virtual bool MakeMove(Point position)
        {
            if(PossibleMove.Contains(position))
            {
                firstTour = false;
                this.position.Change(position);
                return true;
            }
            return false;
        }
    }
}
