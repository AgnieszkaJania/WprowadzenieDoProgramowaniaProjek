using System.Collections.Generic;

namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// Checks if there is a piece at the given position
        /// </summary>
        /// <param name="position">position to check</param>
        /// <param name="moves">Returns the possible moves of the piece</param>
        /// <returns>good truth if the piece exists</returns>
        public bool TryGetMoves(Point position, out List<Point> moves)
        {
            moves = new List<Point>();

            foreach (Piece piece in piecesList)
            {
                if (piece.position == position)
                {//find the piece
                    if (piece.Color == move)
                    {//check if he can make a move
                        moves = piece.PossibleMoves;
                        return true;
                    }
                    else
                    {//if can't
                        return false;
                    }
                }
            }
            //if not found
            return false;
        }
        /// <summary>
        /// Checks whether you can move the piece to the given coordinates
        /// </summary>
        /// <param name="position">piece coords</param>
        /// <param name="coords">place to move</param>
        /// <returns>returns true if the action was successful</returns>
        public bool TryMakeMove(Point position, Point coords, out GameStates status)
        {
            status = GameStates.Game;
            foreach (Piece piece in piecesList)
            {
                //find piece
                if (piece.position == position)
                {
                    //check if he can make a move
                    if (piece.TryMakeMove(coords, mode))
                    {
                        //check if he has beaten anyone
                        foreach (Piece remove in piecesList)
                        {
                            if (remove.position == coords)
                            {
                                if (remove.Color != piece.Color)
                                {
                                    //beat
                                    piecesList.Remove(remove);
                                    break;
                                }
                            }
                        }
                        //make a move
                        move = !move;
                        movesMade.Add(new KeyValuePair<Point, Point>(position, coords));

                        status = Status();

                        return true;
                    }
                    return false;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the king is under attack
        /// </summary>
        /// <param name="color">Color of king</param>
        /// <returns>Returns true if it is under attack</returns>
        public bool IsCheck(bool color)
        {
            //King
            Piece King = new King(new Point(-1, -1), this, color);
            //list of posible enemis moves
            List<Point> EnemyMoves = new List<Point>();
            //get them
            foreach (Piece piece in piecesList)
            {
                if (piece.Color == color)
                {
                    if (piece.PieceName == Pieces.King)
                    {
                        King = piece;
                    }
                }
                else
                {
                    foreach (Point move in piece.PossibleMoves)
                    {
                        EnemyMoves.Add(move);
                    }
                }
            }

            if (EnemyMoves.Contains(King.position))
                return true;
            return false;
        }
        /// <summary>
        /// list of possible game states
        /// </summary>
        public enum GameStates
        {
            Game = 0,
            Mat = 1,
            Draw = 2
        };
        /// <summary>
        /// checks the current status of the board
        /// </summary>
        /// <returns>status name</returns>
        GameStates Status()
        {
            //king
            King king = new King(null, null, move);
            //list of enemy moves
            List<Point> enemyMove = new List<Point>();
            //find object
            foreach (Piece piece in piecesList)
            {
                if (piece.Color == move)
                {
                    //if you can make a move further game possible
                    if (piece.PossibleMoves.Count > 0)
                        return GameStates.Game;
                    //position of king
                    if (piece.PieceName == Pieces.King)
                        king = (King)piece;
                }
                else
                {
                    //get all the fields under your opponent's rule
                    foreach (Point point in piece.PossibleMoves)
                    {
                        if (!enemyMove.Contains(point))
                            enemyMove.Add(point);
                    }
                }
            }
            //if the king is under attack then mate
            if (enemyMove.Contains(king.position))
                return GameStates.Mat;
            //if you can't move and you are not under attack then a draw
            return GameStates.Draw;
        }
        /// <summary>
        /// implementation of the pawn promotion
        /// </summary>
        /// <param name="pawn">pawn to promotion</param>
        void PawnPromotion(Piece pawn)
        {
            if(mode)
            {
                piecesList.Remove(pawn);

                switch(pawnPromotion())
                {
                    case Pieces.Queen:
                        piecesList.Add(new Queen(pawn.position, this, pawn.Color, pawn.FirstTour, pawn.Move));
                        break;
                    case Pieces.Bishop:
                        piecesList.Add(new Bishop(pawn.position, this, pawn.Color, pawn.FirstTour, pawn.Move));
                        break;
                    case Pieces.Rock:
                        piecesList.Add(new Rock(pawn.position, this, pawn.Color, pawn.FirstTour, pawn.Move));
                        break;
                    case Pieces.Knight:
                        piecesList.Add(new Knight(pawn.position, this, pawn.Color, pawn.FirstTour, pawn.Move));
                        break;
                }
            }
        }
    }
}
