using System;
using System.Text;
using System.Collections.Generic;
using ChessLogic;
using System.Reflection.Metadata;

namespace ChessView
{
    /// <summary>
    /// Drawing board
    /// </summary>
    class Program
    {
        //position of cursor
        static Point cursor = new Point(3, 6);
        //selected fields
        static Point selected = new Point(-1, -1);
        static List<Point> movesList = new List<Point>();
        //game logic
        static Game game = new Game();
        //sizes
        static int boardSize = 8;
        const int fieldWidth = 4;
        const int fieldHeight = 3;
        //side
        const bool side = false;
        //way of presentating pieces 1-chars 0-icons
        static short presentationMethod = 0;
        //dictionery pieces and icons
        static Dictionary<string, string> piecesIcons = new Dictionary<string, string> {
            { "King", "♚K" },
            { "Queen", "♛Q"},
            { "Rock", "♜R"},
            { "Bishop", "♝B"},
            { "Knight", "♞k"},
            { "Pawn", "♟P"}
        };

        /// <summary>
        /// drawing all board
        /// </summary>
        static void DrawBoard()
        {
            //board height
            for (int i = 0; i < boardSize; i++)
            {
                //board width
                for (int j = 0; j < boardSize; j++)
                {
                    DrawField(new Point(i, j));
                }
            }
        }

        /// <summary>
        /// drawing single field
        /// </summary>
        /// <param name="point">position of drawing field</param>
        static void DrawField(Point point)
        {
            //check data valid
            if (!point.check(boardSize - 1))
                return;
            //center board
            int shift = (Console.WindowWidth - (boardSize * (fieldWidth + presentationMethod))) / 2;
            //set bg color
            if (point.Equals(cursor))
                Console.BackgroundColor = ConsoleColor.Blue;
            else if (point.Equals(selected))
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            else if (movesList.Contains(point))
                Console.BackgroundColor = ConsoleColor.Red;
            else if (point.AddXY % 2 == 0 == side)
                Console.BackgroundColor = ConsoleColor.Green;
            else
                Console.BackgroundColor = ConsoleColor.White;

            //field width
            for (int i = 0; i < fieldHeight; i++)
            {
                //set cursor position
                Console.CursorTop = point.y * fieldHeight + i;
                Console.CursorLeft = shift + (point.x * (fieldWidth + presentationMethod));
                //field height
                for (int j = 0; j < fieldWidth + presentationMethod; j++)
                {
                    if (i == fieldHeight / 2 && j == (fieldWidth + presentationMethod) / 2 - (1 - presentationMethod) && game.TryGetPiece(point, out bool color, out string piece))
                    {
                        if (color)
                            Console.ForegroundColor = ConsoleColor.Gray;
                        else
                            Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(piecesIcons[piece][presentationMethod]);
                    }
                    else
                        Console.Write(' ');
                }
                Console.WriteLine();
            }
            //set default bgcolor
            Console.ResetColor();
        }
        /// <summary>
        /// change cursor position
        /// </summary>
        /// <param name="position">new cursor position</param>
        static void MoveCursor(Point position)
        {
            //check data valid
            if (!position.check(boardSize - 1)) return;
            //copy old position
            Point old = cursor;
            //confirm new data
            cursor = position;
            //clear old position
            DrawField(old);
            //draw new
            DrawField(position);
        }

        /// <summary>
        /// change selected item
        /// </summary>
        static void Apply()
        {
            if(movesList.Contains(cursor))
            {
                if(game.TryMakeMove(selected, cursor))
                {
                    
                }
                //copy selected
                Point oldSelected = selected;
                //clear selected
                selected = new Point(-1, -1);
                //copy move list
                List<Point> old = movesList;
                //clear move list
                movesList = new List<Point>();
                //clear old position
                foreach (Point tmp in old)
                {
                    DrawField(tmp);
                }
                //clear old selected
                DrawField(oldSelected);
            }
            else if (game.TryGetMoves(cursor, out List<Point> moves))
            {
                //copy selected
                Point oldSelected = selected;
                //change selected point
                selected = cursor;
                //copy move list
                List<Point> old = movesList;
                //replace move list with new list
                movesList = moves;
                //draw new list
                foreach(Point tmp in moves)
                {
                    DrawField(tmp);
                }
                //clear old position
                foreach (Point tmp in old)
                {
                    DrawField(tmp);
                }
                //clear old selected
                DrawField(oldSelected);
            }
            else
            {
                //copy selected
                Point oldSelected = selected;
                //clear selected
                selected = new Point(-1, -1);
                //copy move list
                List<Point> old = movesList;
                //clear move list
                movesList = new List<Point>();
                //clear old position
                foreach (Point tmp in old)
                {
                    DrawField(tmp);
                }
                //clear old selected
                DrawField(oldSelected);
            }
        }

        /// <summary>
        /// main loop for game
        /// </summary>
        static void Chess()
        {
            //draw board
            DrawBoard();
            //infiniti loop
            while (true)
            {
                //set console cursor location
                Console.CursorLeft = 0;
                Console.CursorTop = 0;
                //get input
                ConsoleKey key = Console.ReadKey().Key;
                //select action
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        MoveCursor(cursor + new Point(0, -1));
                        break;
                    case ConsoleKey.DownArrow:
                        MoveCursor(cursor + new Point(0, 1));
                        break;
                    case ConsoleKey.LeftArrow:
                        MoveCursor(cursor + new Point(-1, 0));
                        break;
                    case ConsoleKey.RightArrow:
                        MoveCursor(cursor + new Point(1, 0));
                        break;
                    case ConsoleKey.Enter:
                        Apply();
                        break;
                    case ConsoleKey.NumPad5:
                        movesList = game.AllMoves(false);
                        break;
                    case ConsoleKey.NumPad8:
                        movesList = game.AllMoves(true);
                        break;
                    case ConsoleKey.NumPad2:
                        Console.WriteLine();
                        Console.WriteLine(game.piecesList.Count + "            ");
                        foreach(var tmp in game.piecesList)
                        {
                            Console.WriteLine(tmp.PieceName);
                        }
                        break;
                }
            }
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Chess();
            Console.OutputEncoding = Encoding.Default;
        }
    }
}