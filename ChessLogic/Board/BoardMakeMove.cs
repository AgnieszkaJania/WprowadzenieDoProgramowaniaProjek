using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// trying to make a move
        /// </summary>
        /// <param name="position">Position of pice</param>
        /// <param name="moveTo">Position to move</param>
        /// <param name="status">Out game status</param>
        public bool TryMakeMove(Point position, Point moveTo, out Status status)
        {
            //set game status
            status = Status.Game;
            foreach (Piece piece in CurrentlyPlayingPieces)
            {
                //find piece on position
                if (piece.Position == position)
                {
                    //try to make a move
                    if (piece.MakeMove(moveTo))
                    {
                        //if you succeed, add movement to the list
                        movesMade.Add(new KeyValuePair<Point, Point>(position, moveTo));
                        //change moving side
                        switch (move)
                        {
                            case Side.White:
                                move = Side.Black; break;
                            case Side.Black:
                                move = Side.White; break;
                        }
                        //check if there wasn't an opponent's piece in the given position
                        foreach (Piece remove in CurrentlyPlayingPieces)
                        {
                            if (remove.Position == moveTo)
                            {
                                //if was remove it from the list
                                CurrentlyPlayingPieces.Remove(remove);
                                pieceList.Remove(remove);
                                return true;
                            }
                        }
                        return true;
                    }
                }
            }
            //if finde fail return
            return false;
        }

        /// <summary>
        /// checks what kind of movements the piece can make
        /// </summary>
        /// <param name="position">Position of piece</param>
        /// <param name="moves">Out list of moves</param>
        public bool TryGetMoves(Point position, out List<Point> moves)
        {       
            //create list
            moves = new List<Point>();

            foreach (Piece piece in CurrentlyPlayingPieces)
            {
                //find piece
                if (piece.Position == position)
                {
                    //set the moves
                    moves = piece.PossibleMove;
                    return true;
                }
            }

            return false;
        }

        void PawnPromotion(Pawn pawn)
        {
            //remowe pawn from list
            CurrentlyPlayingPieces.Remove(pawn);
            pieceList.Remove(pawn);
            //Select new piece
            Pieces piece = pawnPromotionSelect();
            //add new pawn
            switch(piece)
            {
                case Pieces.Queen:
                    var Queen = new Queen(pawn.Position, this, pawn.Color, false, movesMade.Count);
                    CurrentlyPlayingPieces.Add(Queen);
                    pieceList.Add(Queen);
                    break;
                case Pieces.Knight:
                    var Knight = new Knight(pawn.Position, this, pawn.Color, false, movesMade.Count);
                    CurrentlyPlayingPieces.Add(Knight);
                    pieceList.Add(Knight);
                    break;
                case Pieces.Rock:
                    var Rock = new Rock(pawn.Position, this, pawn.Color, false, movesMade.Count);
                    CurrentlyPlayingPieces.Add(Rock);
                    pieceList.Add(Rock);
                    break;
                case Pieces.Bishop:
                    var Bishop = new Bishop(pawn.Position, this, pawn.Color, false, movesMade.Count);
                    CurrentlyPlayingPieces.Add(Bishop);
                    pieceList.Add(Bishop);
                    break;
            }
        }
    }
}
