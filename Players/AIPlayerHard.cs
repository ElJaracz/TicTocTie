using System;
using System.Collections.Generic;

namespace TicTacToe.GameEngine
{
    internal class AIPlayerHard
    {
        private Random random = new Random();

        public int GetMove(char[] cells)
        {

            if (cells[5] != 'X' && cells[5] != 'O')
            {
                return 5;
            }

            int blockingMove = FindBlockingMove(cells);
            if (blockingMove != -1)
            {
                return blockingMove;
            }

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

        private int FindBlockingMove(char[] cells)
        {
            int[,] winPatterns = {
        { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, 
        { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 }, 
        { 1, 5, 9 }, { 3, 5, 7 }  
    };

            for (int i = 0; i < winPatterns.GetLength(0); i++) 
            {
                int xCount = 0;
                int emptyCell = -1;

                for (int j = 0; j < winPatterns.GetLength(1); j++) 
                {
                    int pos = winPatterns[i, j]; 

                    if (cells[pos] == 'X') xCount++; // Liczy X gracza
                    if (cells[pos] != 'X' && cells[pos] != 'O') emptyCell = pos; // Znajduje wolne pole
                }

                if (xCount == 2 && emptyCell != -1)
                {
                    return emptyCell; // Zablokowanie wygranej gracza
                }
            }

            return -1; // Brak potrzeby blokowania
        }
    }
}