using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    [Serializable]
    class Player
    {
        public string Piece { get; private set; }
        public string Name { get; private set; }


        public Player(string piece, string name)
        {
            this.Name = name;

            if(piece != "X" && piece != "O")
            {
                this.Piece = GetValidPiece();
            }

            this.Piece = piece;
        }

        private string GetValidPiece()
        {
            string userInput = "U";

            while(userInput != "X" || userInput != "O")
            {
                Console.WriteLine("Enter a valid piece (X or O)");
                userInput = Console.ReadLine();
            }

            return userInput;
        }
    }
}
