using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Players;
using TicTacToe.Managers;

namespace TicTacToe.GameEngine
{
    internal class Turn
    {
        private int choice;
        private Player gamePlayer1;
        private Player gamePlayer2;
        private AIPlayer aiPlayer;
        private AIPlayerHard aiPlayerHard;
        private FileManager fileManager;
        public int turns = 0;
        public Turn(Player gamePlayer1, Player gamePlayer2, AIPlayer aiPlayer, AIPlayerHard aiPlayerHard, FileManager fileManager)
        {
            this.gamePlayer1 = gamePlayer1;
            this.gamePlayer2 = gamePlayer2;
            this.aiPlayer = aiPlayer;
            this.aiPlayerHard = aiPlayerHard;
            this.fileManager = fileManager;
        }

        public void Run(char[] cells, ref int player, bool AI1, bool AI2, bool AIHard, ref int turns)
        {
            Player currentPlayer = (player % 2 != 0) ? gamePlayer1 : gamePlayer2;
            if (AI2 && player % 2 == 0)
            {
                Console.WriteLine("Computer is Thinking...");
                Thread.Sleep(500);
                choice = aiPlayer.GetMove(cells);
            }
            else if (AI1 && player % 2 != 0)
            {
                Console.WriteLine("Computer is Thinking...");
                Thread.Sleep(500);
                choice = aiPlayer.GetMove(cells);
            }
            else if (AIHard && player % 2 == 0)
            {
                Console.WriteLine("Computer is Thinking...");
                Thread.Sleep(500);
                choice = aiPlayerHard.GetMove(cells);
            }
            else
            {
                Console.WriteLine($"{currentPlayer.Nick}, choose your move:");
                choice = currentPlayer.GetMove(cells);
            }
            if (cells[choice] != 'X' && cells[choice] != 'O')
                {
                char symbol = (player % 2 != 0) ? 'X' : 'O';
                cells[choice] = symbol;
                player++;
                turns++;
                fileManager.Save(turns, currentPlayer.Nick, symbol, choice);
            }
            else
            {
                Console.WriteLine("Invalid move! Try again.");
                Thread.Sleep(1000);
            }
        }
    }
}

