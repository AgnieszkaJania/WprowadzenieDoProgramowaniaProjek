namespace ChessLogic
{
    public partial class Piece
    {
        /// <summary>
        /// It informs if the piece has already made a move
        /// </summary>
        protected bool firstTour;
        /// <summary>
        /// Stores chess pieces coordinates on the table
        /// </summary>
        protected Point position;
        /// <summary>
        /// Stores piece color 
        /// </summary>
        protected Board.Side color;
        /// <summary>
        /// Piece type
        /// </summary>
        protected Board.Pieces pieceName;
        /// <summary>
        /// The board on which the piece is located
        /// </summary>
        protected Board board;

        //get data outside
        public Point Position { get => position; }
        public bool FirtTour { get => firstTour; }
        public Board.Side Color { get => color; }
        public Board.Pieces PieceName { get => pieceName; }
    }
}
