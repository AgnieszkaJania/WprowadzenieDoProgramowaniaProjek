using System.Collections.Generic;

namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// Checks if there is a piece on the given position
        /// </summary>
        /// <param name="position">Position to check</param>
        /// <param name="pieceName">return pieceName</param>
        /// <param name="color">return pieceColor</param>
        /// <returns>True if found</returns>
        public bool TryGetPieceNameColorAtPosition(Point position, out string pieceName, out bool color)
        {
            //set default values
            pieceName = "";
            color = false;
            //for all piece
            foreach (Piece piece in piecesList)
            {
                //check if his position matches that given
                if (piece.position == position)
                {
                    //complete the data and finish the work
                    color = piece.Color;
                    pieceName = piece.PieceName;
                    return true;
                }
            }
            //if not found return false
            return false;
        }
        /// <summary>
        /// Checks the possibility of making a short castling
        /// </summary>
        /// <param name="color">king's color</param>
        /// <returns>returns true if possible</returns>
        public bool ShortCastling(bool color)
        {
            //Data Required
            King king = new King(null, null, color);
            List<Rock> rockList = new List<Rock>();
            List<Point> enemyMoves = new List<Point>();
            //find data
            foreach (Piece piece in piecesList)
            {
                if (piece.Color == color)
                {
                    if (piece.PieceName == "King")
                    {
                        if (piece.FirstTour)
                            king = (King)piece;
                        else
                            return false;
                    }
                    else if (piece.PieceName == "Rock")
                        if (piece.FirstTour)
                            rockList.Add((Rock)piece);
                }
                else
                {
                    List<Point> possibleMoves = piece.PossibleMoves;
                    foreach (Point point in possibleMoves)
                    {
                        if (!enemyMoves.Contains(point))
                            enemyMoves.Add(point);
                    }
                }
            }

            //check for free gearing
            if (TryGetPieceNameColorAtPosition(king.position + new Point(1, 0), out string p, out bool c))
                return false;
            if (TryGetPieceNameColorAtPosition(king.position + new Point(2, 0), out p, out c))
                return false;
            //check if they are being attacked
            if (enemyMoves.Contains(king.position))
                return false;
            if (enemyMoves.Contains(king.position + new Point(1, 0)))
                return false;
            if (enemyMoves.Contains(king.position + new Point(2, 0)))
                return false;
            //check if the right tower
            foreach (Rock rock in rockList)
            {
                if (rock.position == king.position + new Point(3, 0))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks the possibility of making a long castling
        /// </summary>
        /// <param name="color">king's color</param>
        /// <returns>returns true if possible</returns>
        public bool LongCastling(bool color)
        {
            //Data Required
            King king = new King(null, null, color);
            List<Rock> rockList = new List<Rock>();
            List<Point> enemyMoves = new List<Point>();
            //find data
            foreach (Piece piece in piecesList)
            {
                if (piece.Color == color)
                {
                    if (piece.PieceName == "King")
                    {
                        if (piece.FirstTour)
                            king = (King)piece;
                        else
                            return false;
                    }
                    else if (piece.PieceName == "Rock")
                        if (piece.FirstTour)
                            rockList.Add((Rock)piece);
                }
                else
                {
                    List<Point> possibleMoves = piece.PossibleMoves;
                    foreach (Point point in possibleMoves)
                    {
                        if (!enemyMoves.Contains(point))
                            enemyMoves.Add(point);
                    }
                }
            }

            //check for free gearing
            if (TryGetPieceNameColorAtPosition(king.position + new Point(-1, 0), out string p, out bool c))
                return false;
            if (TryGetPieceNameColorAtPosition(king.position + new Point(-2, 0), out p, out c))
                return false;
            if (TryGetPieceNameColorAtPosition(king.position + new Point(-3, 0), out p, out c))
                return false;
            //check if they are being attacked
            if (enemyMoves.Contains(king.position))
                return false;
            if (enemyMoves.Contains(king.position + new Point(-1, 0)))
                return false;
            if (enemyMoves.Contains(king.position + new Point(-2, 0)))
                return false;
            //check if the right tower
            foreach (Rock rock in rockList)
            {
                if (rock.position == king.position + new Point(-4, 0))
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Make a short castling
        /// </summary>
        /// <param name="king">the king who performs</param>
        public void MakeShortCastling(King king)
        {
            Piece rock = new Rock(null, null, false);
            foreach (Piece piece in piecesList)
            {
                if (piece.position == king.position + new Point(3, 0))
                {
                    rock = piece;
                    break;
                }
            }

            rock.position = king.position - new Point(-1, 0);
            king.position = king.position - new Point(-2, 0);
        }
        /// <summary>
        /// Make a long castling
        /// </summary>
        /// <param name="king">the king who performs</param>
        public void MakeLongCastling(King king)
        {
            Piece rock = new Rock(null, null, false);
            foreach (Piece piece in piecesList)
            {
                if (piece.position == king.position + new Point(-4, 0))
                {
                    rock = piece;
                    break;
                }
            }

            rock.position = king.position - new Point(1, 0);
            king.position = king.position - new Point(2, 0);
        }
    }
}
