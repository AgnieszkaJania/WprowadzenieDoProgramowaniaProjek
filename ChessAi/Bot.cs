using ChessLogic;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChessAi
{
    public class Bot
    {
        //the number of simulations
        int lenght;
        //playing table
        Board board;

        public Bot(int lenght, Board board)
        {
            this.lenght = lenght;
            this.board = board;
        }

        public void MakeMove()
        {
            
        }

        Board.Pieces PawnPromotion()
        {
            return Board.Pieces.Queen;
        }
    }
}
