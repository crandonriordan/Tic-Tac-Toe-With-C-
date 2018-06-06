using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    [Serializable]
    class Board
    {
        public string[] BoardPieces { get; private set; }

        public Board()
        {
            this.BoardPieces = new string[] { "U", "U", "U", "U", "U", "U", "U", "U", "U" };
        }

        public void setPiece(Player player, int position)
        {

            string playerPiece = player.Piece;
            int newPosition = -1;

            //check for piece already at position
            if(BoardPieces[position] == "U")
            {
                BoardPieces[position] = playerPiece;
            }
            else
            {
                newPosition = GetValidPositionFromUser();
                this.setPiece(player, newPosition);
            }
            
        }

        public int GetValidPositionFromUser()
        {
            int validInput = -1;
            
            while(validInput < 0)
            {
                Console.WriteLine();
                Console.WriteLine("Enter a valid position 0-8:");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int number) && (number > -1 && number < 9))
                {
                    validInput = number;
                }
            }

            return validInput;
        }

    }
}
