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
    class Program
    {
        static void Main(string[] args)
        {
            //WinCondition win = new WinCondition();
            Board board = new Board();
            Renderer renderer = new Renderer(board);

            Engine engine = new Engine(board, renderer);

            engine.Start();

            

        }
    }
}
