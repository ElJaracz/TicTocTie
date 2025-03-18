using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TicTacToe.Managers
{
    internal class StatsManager
    {
        private string filePath = "C:\\Users\\Gorol\\Desktop\\TicTacToe\\Stats.txt";
        public Dictionary<string, int> LoadStats()
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int wins))
                    {
                        stats[parts[0].Trim()] = wins;
                    }
                }
            }
            return stats;
        }

        public void SaveStats(Dictionary<string, int> stats)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false)) 
            {
                foreach (var player in stats.OrderByDescending(x => x.Value))
                {
                    sw.WriteLine($"{player.Key}: {player.Value}");
                }
            }
        }
        public void UpdateStats(string winner)
        {
            Dictionary<string, int> stats = LoadStats();
            if (stats.ContainsKey(winner))
            {
                stats[winner]++;
            }
            else
            {
                stats[winner] = 1;
            }
            SaveStats(stats);
        }
        public void ShowTopPlayers()
        {
            Dictionary<string, int> stats = LoadStats();
            Console.WriteLine("\n==== TOP 5 PLAYERS ====");
            foreach (var player in stats.OrderByDescending(x => x.Value).Take(5))
            {
                Console.WriteLine($"{player.Key}: {player.Value} wins");
            }
            Console.WriteLine("========================\n");
        }
    }
}
