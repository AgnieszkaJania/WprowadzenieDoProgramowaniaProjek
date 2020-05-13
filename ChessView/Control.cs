using ChessLogic;
using System;
using System.Text;

namespace ChessView
{
    class Control
    {
        /// <summary>
        /// Game board control
        /// </summary>
        static void ChessControl(bool side = false)
        {
            //set encoding to utf8
            Console.OutputEncoding = Encoding.UTF8;
            //create Board view
            ChessView board = new ChessView(side);
            //draw a board
            board.DrawBoard();

            //Information about whether the game is still ongoing
            bool game = true;
            //input loop
            while (game)
            {
                //set cursor position
                Console.CursorTop = Console.WindowHeight - 1;
                Console.CursorLeft = 0;

                //download pressed key
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow://Move cursor up
                        board.MoveCursor(new Point(0, -1));
                        break;
                    case ConsoleKey.DownArrow://Move cursor down
                        board.MoveCursor(new Point(0, 1));
                        break;
                    case ConsoleKey.LeftArrow://Move cursor left
                        board.MoveCursor(new Point(-1, 0));
                        break;
                    case ConsoleKey.RightArrow://Move cursor right
                        board.MoveCursor(new Point(1, 0));
                        break;

                    case ConsoleKey.Enter://Make a move or select a piece
                        board.SelectPiece(out var status);
                        //game status
                        switch (status)
                        {
                            case Board.Status.Pat:
                                game = false;
                                break;
                            case Board.Status.Mat:
                                game = false;
                                break;
                        }
                        break;
                }
            }
            //set default encoding
            Console.OutputEncoding = Encoding.Default;
        }

        /// <summary>
        /// Everything starts here
        /// </summary>
        static void Main()
        {
            ChessControl();
        }
    }
}
