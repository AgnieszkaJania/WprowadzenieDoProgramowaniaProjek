using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Transactions;

namespace ChessLogic
{
    public class Pawn : Piece
    {
        protected Action<Pawn> promotion;
        /// <summary>
        /// creating a new piece pawn
        /// </summary>
        /// <param name="promotion">Function to call when pawn reach lasc row</param>
        /// <param name="position">Started position</param>
        /// <param name="board">The board on which the piece is located</param>
        /// <param name="color">Color of piece</param>
        /// <param name="firstTour">If the piece has already made a move</param>
        /// <param name="move">Informs if the piece has already made a move</param>
        public Pawn(Action<Pawn> promotion,Point position, Board board, Board.Side color, bool firstTour = true, int move = -1) : base(position, board, color, firstTour, move)
        {
            this.promotion = promotion;
            pieceName = Board.Pieces.Pawn;
        }
        public int Direction()
        {
            if (Board.Side.Black == color)
                return 1;
            return -1;
        }
        /// <summary>
        /// Creates a list of possible moves
        /// </summary>
        protected override List<Point> Moves()
        {
            //list moves
            var xRay = new List<Point>();
            //pawn movements

            //up
            if (!board.TryGetPieceNameColorAtPosition(position + new Point(0, Direction()), out var _, out var _))
            {
                xRay.Add(position + new Point(0, Direction()));
                //two up
                if (firstTour)
                    if (!board.TryGetPieceNameColorAtPosition(position + new Point(0, 2*Direction()), out var _, out var _))
                        xRay.Add(position + new Point(0, 2 * Direction()));
            }   
            //right
            if(board.EnemyPosition(position + new Point(1, Direction())))
                xRay.Add(position + new Point(1, Direction()));
            //left
            if (board.EnemyPosition(position + new Point(-1, Direction())))
                xRay.Add(position + new Point(-1, Direction()));

            return xRay;
        }

        public override bool MakeMove(Point position)
        {
            bool tmp = base.MakeMove(position);

            switch(Direction())
            {
                case 1:
                    if(this.position.y==7)
                        promotion(this);break;
                case -1:
                    if (this.position.y == 0)
                        promotion(this);break;
            }
            return tmp;
        }
    }
}
