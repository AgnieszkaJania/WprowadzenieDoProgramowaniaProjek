namespace ChessLogic
{
    public partial class Piece
    {
        /// <summary>
        /// creating a new piece
        /// </summary>
        /// <param name="position">Started position</param>
        /// <param name="board">The board on which the piece is located</param>
        /// <param name="color">Color of piece</param>
        /// <param name="firstTour">If the piece has already made a move</param>
        /// <param name="move">Informs if the piece has already made a move</param>
        protected Piece(Point position, Board board, Board.Side color, bool firstTour, int move)
        {
            this.position = position;
            this.board = board;
            this.color = color;
            this.firstTour = firstTour;
            this.move = move;
        }
    }
}
