using System;
using System.Collections.Generic;
using TicTacToe.Players;

namespace TicTacToe.GameEngine
{
    internal class AIPlayer : IPlayer
    {
        private Random random = new Random();
        public int GetMove(char[] cells)
        {
            List<int> availableMoves = new List<int>();

            for (int i = 1; i <= 9; i++)
            {
                if (cells[i] != 'X' && cells[i] != 'O')
                {
                    availableMoves.Add(i);
                }
            }
            if (availableMoves.Count > 0)
            {
                return availableMoves[random.Next(availableMoves.Count)];
            }
            return -1;
        }
    }
}
