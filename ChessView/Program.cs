using System;

namespace ChessView
{
    class Program
    {
        const int BoardSize = 8;
        const int FieldWidth = 5;
        const int FieldHeight = 3;

        static void BoardDraw()
        {
            int HorizontalCentering = (Console.WindowWidth - (BoardSize * FieldWidth)) / 2;
            int VerticalCentering = (Console.WindowHeight - (BoardSize*FieldHeight))/2;

            for(int i=0;i<VerticalCentering;i++)
                Console.WriteLine();
            //board height
            for (int i = 0; i < BoardSize; i++)
            {
                //field height
                for (int k = 0; k < FieldHeight; k++)
                {
                    //centering the board
                    for (int o = 0; o < HorizontalCentering; o++)
                        Console.Write(' ');

                    //board width
                    for (int j = 0; j < BoardSize; j++)
                    {
                        //field color
                        if ((i + j) % 2 == 0)
                            Console.BackgroundColor = ConsoleColor.White;
                        else
                            Console.BackgroundColor = ConsoleColor.Green;

                        //field width
                        for (int l = 0; l < FieldWidth; l++)
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
        }

        static void Main(string[] args)
        {
            BoardDraw();
        }
    }
}
