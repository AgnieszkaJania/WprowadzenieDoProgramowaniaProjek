using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChessLogic.pieces
{
    class King : Piece
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="coords">piece startcoords</param>
        /// <param name="pieces">list of other pieces</param>
        /// <param name="color">piece color</param>
        public King(Point coords, Game board, bool color) : base(coords, board, color)
        {
            pieceName = "King";
        }
        /// <summary>
        /// return list of possible moves
        /// </summary>
        /// <returns></returns>
        public override List<Point> PossibleMoves(bool king = true)
        {
            List<Point> tmp = new List<Point>();
            //check enemi moves
            List<Point> enemyMoves = new List<Point>();
            if (king)
                enemyMoves = other.AllMoves(!color);

            //check all moves around king
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    //excludes the possibility of making an empty move
                    if (!(i == 0 && j == 0))
                    {
                        //Check if the ally is blocking the road
                        if (!other.CheckIfAlly(position + new Point(i, j), color) || !king)
                        {
                            //check if the king doesn't want to come under the beating
                            if (!enemyMoves.Contains(position + new Point(i, j)) || !king)
                            {
                                //add possible
                                tmp.Add(position + new Point(i, j));
                            }
                        }
                    }
                }
            }

            return tmp;
        }
    }
}
