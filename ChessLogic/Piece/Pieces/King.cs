using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ChessLogic
{
    class King : Piece
    {
        /// <summary>
        /// creating a new piece king
        /// </summary>
        /// <param name="position">Started position</param>
        /// <param name="board">The board on which the piece is located</param>
        /// <param name="color">Color of piece</param>
        /// <param name="firstTour">If the piece has already made a move</param>
        /// <param name="move">Informs if the piece has already made a move</param>
        public King(Point position, Board board, Board.Side color, bool firstTour = true, int move = -1) : base(position, board, color, firstTour, move)
        {
            pieceName = Board.Pieces.King;
        }

        /// <summary>
        /// Creates a list of possible moves
        /// </summary>
        protected override List<Point> Moves()
        {
            //list moves
            var xRay = new List<Point>();

            //check all straight and bevels
            //bottom
            if (!board.AllyPosition(position + new Point(0, 1)))
                xRay.Add(position + new Point(0, 1));
            //down right
            if (!board.AllyPosition(position + new Point(1, 1)))
                xRay.Add(position + new Point(1, 1));
            //right top
            if (!board.AllyPosition(position + new Point(1, -1)))
                xRay.Add(position + new Point(1, -1));
            //top
            if (!board.AllyPosition(position + new Point(0, -1)))
                xRay.Add(position + new Point(0, -1));
            //top left
            if (!board.AllyPosition(position + new Point(-1, -1)))
                xRay.Add(position + new Point(-1, -1));
            //left down
            if (!board.AllyPosition(position + new Point(-1, 1)))
                xRay.Add(position + new Point(-1, 1));
            //right
            if (!board.AllyPosition(position + new Point(1, 0)))
            {
                xRay.Add(position + new Point(1, 0));
                if (firstTour)
                    if (!board.AllyPosition(position + new Point(2, 0)))
                        if (board.RockAtPosition(position + new Point(3, 0), out _))
                            xRay.Add(position + new Point(2, 0));
            }
            //left
            if (!board.AllyPosition(position + new Point(-1, 0)))
            {
                xRay.Add(position + new Point(-1, 0));
                if (firstTour)
                    if (!board.AllyPosition(position + new Point(-2, 0)))
                        if (!board.AllyPosition(position + new Point(-3, 0)))
                            if (board.RockAtPosition(position + new Point(-4, 0), out _))
                                xRay.Add(position + new Point(-2, 0));
            }


            return xRay;
        }

        public override bool MakeMove(Point position)
        {
            if (PossibleMove.Contains(position))
            {
                firstTour = false;
                int shift = (position - this.position).x;

                if(Math.Abs(shift)==2)
                {
                    if(shift==-2)
                    {
                        board.RockAtPosition(this.position + new Point(-4, 0), out Piece rock);
                        rock.Position.Change(this.position + new Point(-1, 0));
                    }
                    else
                    {
                        board.RockAtPosition(this.position + new Point(3, 0), out Piece rock);
                        rock.Position.Change(this.position + new Point(1, 0));
                    }
                }

                this.position.Change(position);
                return true;
            }
            return false;
        }

        public bool UnderAttack()
        {
            bool down = true,
                downRight = true,
                right = true,
                rightTop = true,
                top = true,
                topLeft = true,
                left = true,
                leftDown = true;

            //check all straight and bevels
            for (int i = 1; i < 8; i++)
            {
                //down
                if (down)
                {
                    Point tmp = position + new Point(0, i);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            if (type == Board.Pieces.Rock || type == Board.Pieces.Queen)
                                return true;
                        down = false;
                    }
                    else if (!tmp.Between(7))
                        down = false;
                }
                //down right
                if (downRight)
                {
                    Point tmp = position + new Point(i, i);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            if (type == Board.Pieces.Rock || type == Board.Pieces.Queen)
                                return true;
                        downRight = false;
                    }
                    else if (!tmp.Between(7))
                        downRight = false;
                }
                //right
                if (right)
                {
                    Point tmp = position + new Point(i, 0);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            if (type == Board.Pieces.Rock || type == Board.Pieces.Queen)
                                return true;
                        right = false;
                    }
                    else if (!tmp.Between(7))
                        right = false;
                }
                //right top
                if (rightTop)
                {
                    Point tmp = position + new Point(i, -i);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            if (type == Board.Pieces.Rock || type == Board.Pieces.Queen)
                                return true;
                        rightTop = false;
                    }
                    else if (!tmp.Between(7))
                        rightTop = false;
                }
                //top
                if (top)
                {
                    Point tmp = position + new Point(0, -i);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            if (type == Board.Pieces.Rock || type == Board.Pieces.Queen)
                                return true;
                        top = false;
                    }
                    else if (!tmp.Between(7))
                        top = false;
                }
                //top left
                if (topLeft)
                {
                    Point tmp = position + new Point(-i, -i);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            if (type == Board.Pieces.Rock || type == Board.Pieces.Queen)
                                return true;
                        topLeft = false;
                    }
                    else if (!tmp.Between(7))
                        topLeft = false;
                }
                //left
                if (left)
                {
                    Point tmp = position + new Point(-i, 0);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            if (type == Board.Pieces.Rock || type == Board.Pieces.Queen)
                                return true;
                        left = false;
                    }
                    else if (!tmp.Between(7))
                        left = false;
                }
                //left down
                if (leftDown)
                {
                    Point tmp = position + new Point(-i, i);
                    if (board.TryGetPieceNameColorAtPosition(tmp, out var color, out var type))
                    {
                        if (color != Color)
                            if (type == Board.Pieces.Rock || type == Board.Pieces.Queen)
                                return true;
                        leftDown = false;
                    }
                    else if (!tmp.Between(7))
                        leftDown = false;
                }
            }

            return false;
        }
    }
}
