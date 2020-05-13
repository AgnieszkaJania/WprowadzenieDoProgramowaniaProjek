using ChessLogic;
using System;
using System.Collections.Generic;


namespace ChessView
{
    /// <summary>
    /// Visualizes the game board
    /// </summary>
    class ChessView
    {
        //Game board
        Board board;
        //Computer player
        /// <summary>
        /// Sizes for the drawn board
        /// </summary>
        enum Sizes
        {
            Board = 8,
            FieldWidth = 5,
            FieldHeight = 3
        }
        //List of Chess pieces and their representation
        readonly Dictionary<Board.Pieces, string> PieceList = new Dictionary<Board.Pieces, string>
        {
            { Board.Pieces.King, "♚K" },
            { Board.Pieces.Queen, "♛Q"},
            { Board.Pieces.Rock, "♜R"},
            { Board.Pieces.Bishop, "♝B"},
            { Board.Pieces.Knight, "♞k"},
            { Board.Pieces.Pawn, "♟P"}
        };
        //Defines the way chess pieces will be displayed on the screen
        //true - Symbols
        //false - Letters
        bool presentationMethod = true;
        //defines the side on which the player will play
        //true - black
        //false - white
        bool side;
        //position of cursor
        Point cursor = new Point(3, 6);
        //position of selected piece
        Point selected = new Point(-1, -1);
        //list of possible moves to be made by the marked piece
        List<Point> possibleMoves = new List<Point>();
        public ChessView(bool side)
        {
            board = new Board(SelectPawnPromotion);
            this.side = side;
        }
        /// <summary>
        /// Draws the entire game board
        /// </summary>
        public void DrawBoard()
        {
            Console.Clear();
            //board height
            for (int i = 0; i < (int)Sizes.Board; i++)
            {
                //board width
                for (int j = 0; j < (int)Sizes.Board; j++)
                {
                    //draw field
                    DrawSingleField(new Point(j, i));
                }
            }
        }
        /// <summary>
        /// Draws a single field on the board
        /// </summary>
        /// <param name="position">Position of field</param>
        void DrawSingleField(Point position)
        {
            //Check if position is valid
            if (position.Between((int)Sizes.Board - 1))
            {
                //Offset to center horizontally
                int Offset = (Console.WindowWidth - ((int)Sizes.Board * ((int)Sizes.FieldWidth))) / 2;

                //Select background color
                if (position.Equals(cursor))//cursor
                    Console.BackgroundColor = ConsoleColor.Blue;
                else if (position.Equals(selected))//selected field
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                else if (possibleMoves.Contains(position))//selected field possible moves
                    Console.BackgroundColor = ConsoleColor.Red;
                else if (position.XaddY % 2 == 0 == side)//black fields
                    Console.BackgroundColor = ConsoleColor.Green;
                else//white fields
                    Console.BackgroundColor = ConsoleColor.White;

                //Change of width caused by change of presentation
                int changeWidth = (presentationMethod) ? 1 : 0;

                //field height
                for (int i = 0; i < (int)Sizes.FieldHeight; i++)
                {
                    //set console cursor positions
                    Console.CursorTop = position.y * (int)Sizes.FieldHeight + i;
                    Console.CursorLeft = position.x * ((int)Sizes.FieldWidth - changeWidth) + Offset;
                    //field width
                    for (int j = 0; j < (int)Sizes.FieldWidth - changeWidth; j++)
                    {
                        //chek if is centered
                        if (i == (int)Sizes.FieldHeight / 2 && j == (int)Sizes.FieldWidth / 2 - changeWidth)
                        {
                            //check if there is a piece in the given position
                            if (board.TryGetPieceNameColorAtPosition(position, out Board.Side color, out Board.Pieces name))
                            {
                                switch (color)
                                {
                                    case Board.Side.Black:
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        break;
                                    case Board.Side.White:
                                        Console.ForegroundColor = ConsoleColor.Gray;
                                        break;
                                }
                                switch (presentationMethod)
                                {
                                    case true:
                                        Console.Write(PieceList[name][0]);
                                        break;
                                    case false:
                                        Console.Write(PieceList[name][1]);
                                        break;
                                }
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                }
                //reset colors
                Console.ResetColor();
            }
        }
        /// <summary>
        /// Choosing pawn promotion
        /// </summary>
        /// <returns></returns>
        public Board.Pieces SelectPawnPromotion()
        {
            //default value
            Board.Pieces piece = Board.Pieces.NULL;
            while (piece == Board.Pieces.NULL)
            {
                //download key
                ConsoleKey key = Console.ReadKey().Key;
                Console.Clear();

                Console.WriteLine("Wybierz awans pionka");
                //show options
                if (presentationMethod)//0
                {
                    Console.WriteLine($"1) {PieceList[Board.Pieces.Queen][0]}");
                    Console.WriteLine($"2) {PieceList[Board.Pieces.Bishop][0]}");
                    Console.WriteLine($"3) {PieceList[Board.Pieces.Rock][0]}");
                    Console.WriteLine($"4) {PieceList[Board.Pieces.Knight][0]}");
                }
                else//1
                {
                    Console.WriteLine($"1) {PieceList[Board.Pieces.Queen][1]}");
                    Console.WriteLine($"2) {PieceList[Board.Pieces.Bishop][1]}");
                    Console.WriteLine($"3) {PieceList[Board.Pieces.Rock][1]}");
                    Console.WriteLine($"4) {PieceList[Board.Pieces.Knight][1]}");
                }

                switch (key)
                {
                    case ConsoleKey.D1:
                        piece = Board.Pieces.Queen;
                        break;
                    case ConsoleKey.D2:
                        piece = Board.Pieces.Bishop;
                        break;
                    case ConsoleKey.D3:
                        piece = Board.Pieces.Rock;
                        break;
                    case ConsoleKey.D4:
                        piece = Board.Pieces.Knight;
                        break;
                }
            }

            return piece;
        }
        /// <summary>
        /// Changes the cursor position
        /// </summary>
        /// <param name="shift">cursor shift</param>
        public void MoveCursor(Point shift)
        {
            //calculate new cursor position
            Point position = cursor + shift;
            //check data valid
            if (position.Between((int)Sizes.Board - 1))
            {
                //copy old cursor position
                Point OldCursor = cursor;
                //enter a new curosr position
                cursor = position;

                //clear old cursor position field
                DrawSingleField(OldCursor);
                //draw ne cursor position
                DrawSingleField(position);
            }
        }
        /// <summary>
        /// Sets the piece under the cursor to selected or moves the selected piece
        /// </summary>
        public void SelectPiece(out Board.Status game)
        {
            game = Board.Status.Game;
            if (board.TryMakeMove(selected, cursor, out Board.Status status))
            {//Making a move
                //clear selected
                selected = new Point(-1, -1);
                //clear moves
                possibleMoves.Clear();
                //draw board
                DrawBoard();
                //change status
                game = status;
            }
            else if (board.TryGetMoves(cursor, out List<Point> moves))
            {//Change selection
                //copy and replace selected
                Point oldSelected = selected;
                selected = cursor;
                //copy and replace moves
                List<Point> oldMoves = possibleMoves;
                possibleMoves = moves;
                //clear old
                foreach (Point point in oldMoves)
                {
                    DrawSingleField(point);
                }
                //drawe new
                foreach (Point point in possibleMoves)
                {
                    DrawSingleField(point);
                }
                //clear old selected
                try
                {
                    DrawSingleField(oldSelected);
                }
                catch (Exception) { }
            }
            else if (selected.Between((int)Sizes.Board - 1))
            {//Deselect
                //copy and replace selected
                Point oldSelected = selected;
                selected = new Point(-1, -1);
                //copy and replace moves
                List<Point> oldMoves = possibleMoves;
                possibleMoves = new List<Point>();
                //clear old
                foreach (Point point in oldMoves)
                {
                    DrawSingleField(point);
                }
                //clear old selected
                DrawSingleField(oldSelected);
            }
        }
    }
}
