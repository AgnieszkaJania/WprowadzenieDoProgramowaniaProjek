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
        readonly Dictionary<string, string> PieceList = new Dictionary<string, string>
        {
            { "King", "♚K" },
            { "Queen", "♛Q"},
            { "Rock", "♜R"},
            { "Bishop", "♝B"},
            { "Knight", "♞k"},
            { "Pawn", "♟P"}
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
            board = new Board();
            this.side = side;
        }
        /// <summary>
        /// Draws the entire game board
        /// </summary>
        public void DrawBoard()
        {
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
                else if (position.xADDy % 2 == 0 == side)//black fields
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
                            if (board.TryGetPieceNameColorAtPosition(position, out string name, out bool color))
                            {
                                switch (color)
                                {
                                    case true:
                                        Console.ForegroundColor = ConsoleColor.Black;
                                        break;
                                    case false:
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
            else
            {
                //if you try to draw outside the board, display error
                throw new ArgumentException($"You are trying to draw a field outside the board: {position.ToString()}");
            }
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
        public void SelectPiece(out Board.GameStates game)
        {
            game = Board.GameStates.Game;
            if (board.TryMakeMove(selected, cursor, out Board.GameStates status))
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
