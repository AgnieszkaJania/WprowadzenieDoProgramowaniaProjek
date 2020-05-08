using System;
using System.Collections.Generic;
using System.Linq;
using ChessLogic;

namespace ChessView
{
    /// <summary>
    /// Drawing board
    /// </summary>
    class Program
    {
        //pieces icons
        static Dictionary<string, char> piecesIcons = new Dictionary<string, char>();
        static Chess Board;
        //if even, it is played as white else black
        const int start = 0;
        //size of board
        const int boardSize = 8;
        //field size
        const int fieldWidth = 4;
        const int fieldHeight = 3;
        //position of cursor
        static int positionX = 3;
        static int positionY = 7;
        //position of selected field
        static int selectedX = -1;
        static int selectedY = -1;

        /// <summary>
        /// Draw a Board
        /// </summary>
        static void BoardDraw()
        {
            //board height
            for (int i = 0; i < boardSize; i++)
            {
                //board width
                for (int j = 0; j < boardSize; j++)
                {
                    DrawField(i, j);
                }
            }
        }
        static Random R = new Random();
        /// <summary>
        /// Draw a single field
        /// </summary>
        /// <param name="x">Field position X</param>
        /// <param name="y">Field position Y</param>
        static void DrawField(int x, int y)
        {
            int HorizontalCentering = (Console.WindowWidth - (boardSize * fieldWidth)) / 2;
            //check data valid
            if (y < 0) return;
            if (y >= boardSize) return;
            if (x < 0) return;
            if (x >= boardSize) return;

            //select color
            if (x == selectedX && y == selectedY)
                Console.BackgroundColor = ConsoleColor.Red;
            else if (x == positionX && y == positionY)
                Console.BackgroundColor = ConsoleColor.Blue;
            else if ((x + y + start) % 2 == 0)
                Console.BackgroundColor = ConsoleColor.Green;
            else
                Console.BackgroundColor = ConsoleColor.White;

            //draw field
            for (int i = 0; i < fieldHeight; i++)
            {
                Console.CursorTop = y * fieldHeight + i;
                Console.CursorLeft = HorizontalCentering + (x * fieldWidth);
                for (int j = 0; j < fieldWidth; j++)
                {
                    if (i == fieldHeight / 2 && j == (fieldWidth / 2) - 1)
                    {
                            Console.Write(piecesIcons.Values.ToArray()[R.Next(0,6)]);
                    }
                    else
                        Console.Write(' ');
                }
            }

            //set default color
            Console.ResetColor();

            //set default cursor position
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
        }

        /// <summary>
        /// Changes the position of the pointer
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        static void Apply(int x, int y)
        {
            //check data valid
            if (y < 0) return;
            if (y >= boardSize) return;
            if (x < 0) return;
            if (x >= boardSize) return;

            //create a copy of the value
            int OldPositionX = positionX;
            int OldPositionY = positionY;
            //confirm new data
            positionX = x;
            positionY = y;
            //clear old pointer position
            DrawField(OldPositionX, OldPositionY);

            //draw new position
            DrawField(positionX, positionY);
        }
        /// <summary>
        /// change selection
        /// </summary>
        /// <param name="x">Position X</param>
        /// <param name="y">Position Y</param>
        static void ChangeSelected(int x, int y)
        {
            //check data valid
            if (y < 0) return;
            if (y >= boardSize) return;
            if (x < 0) return;
            if (x >= boardSize) return;

            if (selectedX < 0 || selectedY < 0)
            {
                selectedX = x;
                selectedY = y;

                //clear old pointer position
                DrawField(selectedX, selectedY);
            }
            else
            {
                //create a copy of the value
                int OldSelectedX = selectedX;
                int OldSelectedY = selectedY;

                //confirm new data
                selectedX = -1;
                selectedY = -1;

                //clear old pointer position
                DrawField(OldSelectedX, OldSelectedY);
            }
        }
        /// <summary>
        /// Control support
        /// </summary>
        static void Control()
        {
            ConsoleKey key = Console.ReadKey().Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    Apply(positionX, positionY - 1);
                    break;
                case ConsoleKey.DownArrow:
                    Apply(positionX, positionY + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    Apply(positionX - 1, positionY);
                    break;
                case ConsoleKey.RightArrow:
                    Apply(positionX + 1, positionY);
                    break;
                case ConsoleKey.Enter:
                    ChangeSelected(positionX, positionY);
                    break;
                default:
                    Console.CursorLeft = 0;
                    Console.CursorTop = 0;
                    break;
            }
        }
        /// <summary>
        /// Main loop
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //set encoding to utf8
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //init Pieces
            piecesIcons.Add("King", '♚');
            piecesIcons.Add("Queen", '♛');
            piecesIcons.Add("Rock", '♜');
            piecesIcons.Add("Bishop", '♝');
            piecesIcons.Add("Knight", '♞');
            piecesIcons.Add("Pawn", '♟');

            ////draw board
            BoardDraw();
            ////wait for inputs
            while (true)
            {
                Control();
            }
        }
    }
}