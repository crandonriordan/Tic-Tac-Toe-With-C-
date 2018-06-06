using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    [Serializable]
    class Renderer
    {

        private Board board;

        public Renderer(Board board)
        {
            this.board = board;
        }

        public void DisplayCurrentBoard()
        {
            string[] boardPieces = board.BoardPieces;
            Console.WriteLine($"{boardPieces[0]} | {boardPieces[1]} | {boardPieces[2]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{boardPieces[3]} | {boardPieces[4]} | {boardPieces[5]}");
            Console.WriteLine("---------");
            Console.WriteLine($"{boardPieces[6]} | {boardPieces[7]} | {boardPieces[8]}");
            Console.WriteLine();
            Console.WriteLine();

        }

    }
}
