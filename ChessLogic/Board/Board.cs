using System;

namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// Create new board
        /// </summary>
        /// <param name="init">Create a start position</param>
        /// <param name="pawnPromotion">Function to select a pawn promotion</param>
        public Board(Func<Pieces> pawnPromotion, bool init = true)
        {
            pawnPromotionSelect = pawnPromotion;
            if (init)
            {
                //Set who start
                move = Side.White;

                //Add pieces
                //King
                blackChessPieces.Add(new King(new Point(4, 0), this, Side.Black));
                blackKing = (King)blackChessPieces[0];
                whiteChessPieces.Add(new King(new Point(4, 7), this, Side.White));
                whiteKing = (King)whiteChessPieces[0];
                //Queen
                blackChessPieces.Add(new Queen(new Point(3, 0), this, Side.Black));
                whiteChessPieces.Add(new Queen(new Point(3, 7), this, Side.White));
                //Rock
                blackChessPieces.Add(new Rock(new Point(0, 0), this, Side.Black));
                blackChessPieces.Add(new Rock(new Point(7, 0), this, Side.Black));
                whiteChessPieces.Add(new Rock(new Point(0, 7), this, Side.White));
                whiteChessPieces.Add(new Rock(new Point(7, 7), this, Side.White));
                //Bishop
                blackChessPieces.Add(new Bishop(new Point(2, 0), this, Side.Black));
                blackChessPieces.Add(new Bishop(new Point(5, 0), this, Side.Black));
                whiteChessPieces.Add(new Bishop(new Point(2, 7), this, Side.White));
                whiteChessPieces.Add(new Bishop(new Point(5, 7), this, Side.White));
                //Knight
                blackChessPieces.Add(new Knight(new Point(1, 0), this, Side.Black));
                blackChessPieces.Add(new Knight(new Point(6, 0), this, Side.Black));
                whiteChessPieces.Add(new Knight(new Point(1, 7), this, Side.White));
                whiteChessPieces.Add(new Knight(new Point(6, 7), this, Side.White));
                //piece
                blackChessPieces.Add(new Pawn(PawnPromotion, new Point(0, 1), this, Side.Black));
                blackChessPieces.Add(new Pawn(PawnPromotion, new Point(1, 1), this, Side.Black));
                blackChessPieces.Add(new Pawn(PawnPromotion, new Point(2, 1), this, Side.Black));
                blackChessPieces.Add(new Pawn(PawnPromotion, new Point(3, 1), this, Side.Black));
                blackChessPieces.Add(new Pawn(PawnPromotion, new Point(4, 1), this, Side.Black));
                blackChessPieces.Add(new Pawn(PawnPromotion, new Point(5, 1), this, Side.Black));
                blackChessPieces.Add(new Pawn(PawnPromotion, new Point(6, 1), this, Side.Black));
                blackChessPieces.Add(new Pawn(PawnPromotion, new Point(7, 1), this, Side.Black));
                //-------
                whiteChessPieces.Add(new Pawn(PawnPromotion, new Point(0, 6), this, Side.White));
                whiteChessPieces.Add(new Pawn(PawnPromotion, new Point(1, 6), this, Side.White));
                whiteChessPieces.Add(new Pawn(PawnPromotion, new Point(2, 6), this, Side.White));
                whiteChessPieces.Add(new Pawn(PawnPromotion, new Point(3, 6), this, Side.White));
                whiteChessPieces.Add(new Pawn(PawnPromotion, new Point(4, 6), this, Side.White));
                whiteChessPieces.Add(new Pawn(PawnPromotion, new Point(5, 6), this, Side.White));
                whiteChessPieces.Add(new Pawn(PawnPromotion, new Point(6, 6), this, Side.White));
                whiteChessPieces.Add(new Pawn(PawnPromotion, new Point(7, 6), this, Side.White));

                //create main list
                foreach (Piece piece in blackChessPieces)
                {
                    pieceList.Add(piece);
                }
                foreach (Piece piece in whiteChessPieces)
                {
                    pieceList.Add(piece);
                }
            }
        }

        public Board Copy(Func<Pieces> pawnPromotion = null, bool init = false, Mode mode = Mode.Test)
        {
            Board tmp = new Board(pawnPromotion, init);

            foreach (Piece piece in pieceList)
            {
                switch (piece.PieceName)
                {
                    case Pieces.King:
                        var king = (new King(new Point(piece.Position), tmp, piece.Color, piece.FirtTour));
                        tmp.pieceList.Add(king);
                        if (king.Color == Side.White)
                        {
                            tmp.whiteChessPieces.Add(king);
                            tmp.whiteKing = king;
                        }
                        else
                        {
                            tmp.blackChessPieces.Add(king);
                            tmp.blackKing = king;
                        }
                        break;
                    case Pieces.Bishop:
                        var bishop = (new Bishop(new Point(piece.Position), tmp, piece.Color, piece.FirtTour));
                        tmp.pieceList.Add(bishop);
                        if (bishop.Color == Side.White)
                            tmp.whiteChessPieces.Add(bishop);
                        else
                            tmp.blackChessPieces.Add(bishop);
                        break;
                    case Pieces.Knight:
                        var knight = (new Knight(new Point(piece.Position), tmp, piece.Color, piece.FirtTour));
                        tmp.pieceList.Add(knight);
                        if (knight.Color == Side.White)
                            tmp.whiteChessPieces.Add(knight);
                        else
                            tmp.blackChessPieces.Add(knight);
                        break;
                    case Pieces.Pawn:
                        var pawn = (new Pawn(tmp.PawnPromotion, new Point(piece.Position), tmp, piece.Color, piece.FirtTour));
                        tmp.pieceList.Add(pawn);
                        if (pawn.Color == Side.White)
                            tmp.whiteChessPieces.Add(pawn);
                        else
                            tmp.blackChessPieces.Add(pawn);
                        break;
                    case Pieces.Queen:
                        var queen = (new Queen(new Point(piece.Position), tmp, piece.Color, piece.FirtTour));
                        tmp.pieceList.Add(queen);
                        if (queen.Color == Side.White)
                            tmp.whiteChessPieces.Add(queen);
                        else
                            tmp.blackChessPieces.Add(queen);
                        break;
                    case Pieces.Rock:
                        var rock = (new Rock(new Point(piece.Position), tmp, piece.Color, piece.FirtTour));
                        tmp.pieceList.Add(rock);
                        if (rock.Color == Side.White)
                            tmp.whiteChessPieces.Add(rock);
                        else
                            tmp.blackChessPieces.Add(rock);
                        break;
                }
            }
            tmp.mode = mode;
            tmp.move = move;

            return tmp;
        }

        public bool Check()
        {
            if (!currentlyNotPlayingKing.UnderAttack())
                return false;
            return true;
        }
    }
}
