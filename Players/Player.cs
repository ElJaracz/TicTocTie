using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.GameEngine;

namespace TicTacToe.Players
{
    internal class Player : IPlayer
    {
        int choice;
        public string Nick { get; private set; }

        public Player(string nick)
        {
            Nick = nick;

        }
        public int GetMove(char[] cells)
        {
            while (true)
            {

                string input = Console.ReadLine();
                if (!int.TryParse(input, out choice))
                {
                    Console.WriteLine("Invalide Choice!");
                    continue;
                }
                if (choice < 1 || choice > 9)
                {
                    Console.WriteLine("Invalide Choice!");
                    continue;
                }
                if (cells[choice] == 'X' || cells[choice] == 'O')
                {
                    Console.WriteLine("The row {0} is already marked with {1}", choice, cells[choice]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Please wait 1 second board is loading again.....");
                    Thread.Sleep(1000);

                    continue;
                }
                return choice;
            }
        }
    }
   
}
