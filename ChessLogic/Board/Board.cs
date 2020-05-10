namespace ChessLogic
{
    public partial class Board
    {
        /// <summary>
        /// make pieces on the board
        /// </summary>
        public void Init()
        {
            //kings
            piecesList.Add(new King(new Point(4, 0), this, true));
            piecesList.Add(new King(new Point(4, 7), this, false));
            ////queens
            piecesList.Add(new Queen(new Point(3, 0), this, true));
            piecesList.Add(new Queen(new Point(3, 7), this, false));
            //Pawn Black
            piecesList.Add(new Pawn(new Point(0, 1), this, true));
            piecesList.Add(new Pawn(new Point(1, 1), this, true));
            piecesList.Add(new Pawn(new Point(2, 1), this, true));
            piecesList.Add(new Pawn(new Point(3, 1), this, true));
            piecesList.Add(new Pawn(new Point(4, 1), this, true));
            piecesList.Add(new Pawn(new Point(5, 1), this, true));
            piecesList.Add(new Pawn(new Point(6, 1), this, true));
            piecesList.Add(new Pawn(new Point(7, 1), this, true));
            //Pawn White
            piecesList.Add(new Pawn(new Point(0, 6), this, false));
            piecesList.Add(new Pawn(new Point(1, 6), this, false));
            piecesList.Add(new Pawn(new Point(2, 6), this, false));
            piecesList.Add(new Pawn(new Point(3, 6), this, false));
            piecesList.Add(new Pawn(new Point(4, 6), this, false));
            piecesList.Add(new Pawn(new Point(5, 6), this, false));
            piecesList.Add(new Pawn(new Point(6, 6), this, false));
            piecesList.Add(new Pawn(new Point(7, 6), this, false));
            //knight
            piecesList.Add(new Knight(new Point(1, 0), this, true));
            piecesList.Add(new Knight(new Point(6, 0), this, true));
            piecesList.Add(new Knight(new Point(1, 7), this, false));
            piecesList.Add(new Knight(new Point(6, 7), this, false));
            ////rock
            piecesList.Add(new Rock(new Point(0, 0), this, true));
            piecesList.Add(new Rock(new Point(7, 0), this, true));
            piecesList.Add(new Rock(new Point(0, 7), this, false));
            piecesList.Add(new Rock(new Point(7, 7), this, false));
            ////Bishop
            piecesList.Add(new Bishop(new Point(2, 0), this, true));
            piecesList.Add(new Bishop(new Point(5, 0), this, true));
            piecesList.Add(new Bishop(new Point(2, 7), this, false));
            piecesList.Add(new Bishop(new Point(5, 7), this, false));
        }
        /// <summary>
        /// Makes copies of the current table
        /// </summary>
        public Board Copy()
        {
            //create new board
            Board newBoard = new Board(false);
            //copy all active pieces
            foreach (Piece piece in piecesList)
            {
                //select piece
                switch (piece.PieceName)
                {
                    case "King":
                        newBoard.piecesList.Add(new King(new Point(piece.position.x, piece.position.y), newBoard, piece.Color, piece.FirstTour));
                        break;
                    case "Queen":
                        newBoard.piecesList.Add(new Queen(new Point(piece.position.x, piece.position.y), newBoard, piece.Color, piece.FirstTour, piece.Move));
                        break;
                    case "Rock":
                        newBoard.piecesList.Add(new Rock(new Point(piece.position.x, piece.position.y), newBoard, piece.Color, piece.FirstTour, piece.Move));
                        break;
                    case "Bishop":
                        newBoard.piecesList.Add(new Bishop(new Point(piece.position.x, piece.position.y), newBoard, piece.Color, piece.FirstTour, piece.Move));
                        break;
                    case "Knight":
                        newBoard.piecesList.Add(new Knight(new Point(piece.position.x, piece.position.y), newBoard, piece.Color, piece.FirstTour, piece.Move));
                        break;
                    case "Pawn":
                        newBoard.piecesList.Add(new Pawn(new Point(piece.position.x, piece.position.y), newBoard, piece.Color, piece.FirstTour, piece.Move));
                        break;
                }
            }
            //return
            return newBoard;
        }
    }
}
