using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace TicTacToe
{
    [Serializable]
    class Engine
    {
        private Board Board { get; set; }
        public Renderer Renderer { get; private set; }
        public Player PlayerOne { get; private set; }
        public Player PlayerTwo { get; private set; }
        public Player WhoseTurn { get; private set; }
        public WinCondition Win { get; private set; }


        public Engine(Board board, Renderer renderer)
        {
            this.Board = board;
            this.Renderer = renderer;
            this.Win = new WinCondition(Board);

            Console.WriteLine("Enter the name of the first player (X)");
            string playerOneName = Console.ReadLine();
            this.PlayerOne = new Player("X", playerOneName);

            this.WhoseTurn = PlayerOne;

            Console.WriteLine("Enter the name of the first player (O)");
            string playerTwoName = Console.ReadLine();
            this.PlayerTwo = new Player("O", playerTwoName);
        }
        
        public void PrintPlayers()
        {
            Console.WriteLine($"Player one is {PlayerOne.Name}. Player two is {PlayerTwo.Name}");
        }

        public void Start()
        {
            PrintColoredMessage(ConsoleColor.Green, "Welcome to v0.1 of Tic-Tac-Toe");

            int numOfTurns = 0;

            while(numOfTurns < 9)
            {
                PrintColoredMessage(ConsoleColor.Red, "If you'd like to save type save");
                string wantsToSave = Console.ReadLine();
                if (wantsToSave.ToLower() == "save")
                    Save();

                PrintColoredMessage(ConsoleColor.Red, "If you'd like to load type load");
                string wantsToLoad = Console.ReadLine();
                if (wantsToLoad.ToLower() == "load")
                {
                    Engine loadedEngine = Load();
                    loadedEngine.Start();

                }


                PrintColoredMessage(ConsoleColor.Cyan, $"{WhoseTurn.Name} is up now!");

                Board.setPiece(WhoseTurn, Board.GetValidPositionFromUser());

                Renderer.DisplayCurrentBoard();

                if(CheckWinner())
                {
                    break;
                }

                ToggleTurn();



                numOfTurns++;
            }

            


        }

        private void PrintColoredMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }

        private void ToggleTurn()
        {
            if (WhoseTurn == PlayerOne)
                WhoseTurn = PlayerTwo;
            else
                WhoseTurn = PlayerOne;

        }

        private bool CheckWinner()
        {
            bool currentPlayerWon = Win.DidPlayerWin(WhoseTurn.Piece);

            if(currentPlayerWon)
            {
                PrintColoredMessage(ConsoleColor.Blue, $"Congrats, {WhoseTurn.Name}, you won!");
            }

            return currentPlayerWon;
        }

        public void Save()
        {
            Engine engineToSave = this;
            IFormatter formatter = new BinaryFormatter();
            Console.Write("Enter a save name:");
            string fileName = Console.ReadLine() + ".bin";
            Stream stream = new FileStream(fileName,
                                     FileMode.Create,
                                     FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, engineToSave);
            stream.Close();
        }

        public Engine Load()
        {
            Console.Write("Enter the file name:");
            string fileName = Console.ReadLine();

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileName,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
            Engine engine = (Engine)formatter.Deserialize(stream);
            stream.Close();

            return engine;
        }

        
    }
}
