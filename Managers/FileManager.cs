using System;
using System.IO;

namespace TicTacToe.Managers
{
    internal class FileManager
    {
        private string filePath;
        public FileManager(string player1Nick, string player2Nick)
        {
            string sanitizedPlayer1 = player1Nick.Replace(" ", "_");
            string sanitizedPlayer2 = player2Nick.Replace(" ", "_");
            filePath = $"C:\\Users\\Gorol\\Desktop\\TicTacToe\\{sanitizedPlayer1}_vs_{sanitizedPlayer2}.txt";
        }
        public void Save(int turnNumber, string playerNick, char symbol, int choice)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    sw.WriteLine($"Turn {turnNumber}: {playerNick} ({symbol}) chose cell {choice}.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
        public void SaveResult(string winner, bool isDraw)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, true))
                {
                    if (isDraw)
                    {
                        sw.WriteLine("Game ended in a DRAW.");
                    }
                    else
                    {
                        sw.WriteLine($"{winner} WINS! 🏆");
                    }
                    sw.WriteLine("====================================\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
        }
    }
}
