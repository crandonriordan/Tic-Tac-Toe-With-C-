using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    [Serializable]
    class WinCondition
    {

        public List<int[]> WinConditions { get; set; }
        public Board Board { get; private set; }
        
        public WinCondition(Board board)
        {
            WinConditions = new List<int[]>
            {
                new int[] { 0, 1, 2 },
                new int[] { 3, 4, 5 },
                new int[] { 6, 7, 8 },
                new int[] { 0, 3, 6 },
                new int[] { 1, 4, 7 },
                new int[] { 2, 5, 8 },
                new int[] { 0, 4, 8 },
                new int[] { 2, 4, 6 }
            };

            this.Board = board;
        }

        public bool DidPlayerWin(string playerPiece)
        {
            bool didTheyWin = false;

            WinConditions.ForEach(setOfWinConditions =>
            {

                if(Board.BoardPieces[setOfWinConditions[0]] == playerPiece && 
                Board.BoardPieces[setOfWinConditions[1]] == playerPiece
                && Board.BoardPieces[setOfWinConditions[2]] == playerPiece)
                {
                    didTheyWin = true;
                }

            });

            return didTheyWin;
        }




    }
}
