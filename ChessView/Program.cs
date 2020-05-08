using System;
using System.Text;
using System.Collections.Generic;
using ChessLogic;

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
        static List<Point> selected = new List<Point>();
        //game logic
        static Game game = new Game();
        //sizes
        static int boardSize = 8;
        const int fieldWidth = 4;
        const int fieldHeight = 3;
        //side
        const bool side = false;
        //dictionery pieces and icons
        static Dictionary<string, char> piecesIcons = new Dictionary<string, char> {
            { "King", '♚' },
            { "Queen", '♛'},
            { "Rock", '♜'},
            { "Bishop", '♝'},
            { "Knight", '♞'},
            { "Pawn", '♟'}
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
            int shift = (Console.WindowWidth - (boardSize * fieldWidth)) / 2;
            //set bg color
            if (point.Equals(cursor))
                Console.BackgroundColor = ConsoleColor.Blue;
            else if (point.AddXY % 2 == 0 == side)
                Console.BackgroundColor = ConsoleColor.Green;
            else
                Console.BackgroundColor = ConsoleColor.White;

            //field width
            for (int i = 0; i < fieldHeight; i++)
            {
                //set cursor position
                Console.CursorTop = point.y * fieldHeight + i;
                Console.CursorLeft = shift + (point.x * fieldWidth);
                //field height
                for (int j = 0; j < fieldWidth; j++)
                {
                    if (i == fieldHeight / 2 && j == fieldWidth / 2 - 1)
                        Console.Write(piecesIcons["King"]);
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
        static public void MoveCursor(Point position)
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
        /// 
        /// </summary>
        static void Apply()
        {

        }

        /// <summary>
        /// main loop for game
        /// </summary>
        static void Chess()
        {
            //draw board
            DrawBoard();
            //infiniti loop
            while(true)
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
                        MoveCursor(cursor + new Point(0,-1));
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