using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Managers;
using TicTacToe.Players;

namespace TicTacToe.GameEngine
{
     class Menu
    {
        public bool AI1 {  get; private set; }
        public bool AI2 { get; private set; }
        public bool AIHard { get; private set; }

        public Menu()
        {
            AI1 = false;
            AI2 = false;
            AIHard = false;
        }
        public GameEngine Start()
        {

            Console.Clear();
            Console.WriteLine("##############################");
            Console.WriteLine("#      TicTacToe Game!!!     #");
            Console.WriteLine("##############################");
            Console.WriteLine("#                            #");
            Console.WriteLine("#            Menu            #");
            Console.WriteLine("#                            #");
            Console.WriteLine("#   1. Player vs Player      #");
            Console.WriteLine("#                            #");
            Console.WriteLine("#   2. Player vs Computer    #");
            Console.WriteLine("#                            #");
            Console.WriteLine("#   3. TEST                  #");
            Console.WriteLine("#                            #");
            Console.WriteLine("#   4. Statistic             #");
            Console.WriteLine("#                            #");
            Console.WriteLine("##############################");

            string gameMode;
            string Level;
            string nick = "";
            string nick2 = "";

            do
            {
                Console.WriteLine("Choose mode (1/2/3/4):");
                gameMode = Console.ReadLine();
            } while (gameMode != "1" && gameMode != "2" && gameMode != "3" && gameMode != "4");

            if (gameMode == "1")
            {
                AI1 = false;
                AI2 = false;
                Console.WriteLine("Player 1, choose your Nick:");
                nick = Console.ReadLine();
                Console.WriteLine("Player 2, choose your Nick:");
                nick2 = Console.ReadLine();

            }
            else if (gameMode == "2")
            {
                Console.Clear();
                Console.WriteLine("##############################");
                Console.WriteLine("#      TicTacToe Game!!!     #");
                Console.WriteLine("##############################");
                Console.WriteLine("#                            #");
                Console.WriteLine("#        Choose Level        #");
                Console.WriteLine("#                            #");
                Console.WriteLine("#   1. Easy                  #");
                Console.WriteLine("#                            #");
                Console.WriteLine("#   2. Hard                  #");
                Console.WriteLine("#                            #");
                Console.WriteLine("#   3. Return                #");
                Console.WriteLine("#                            #");
                Console.WriteLine("##############################");

                do
                {
                    Console.WriteLine("Choose Level:");
                    Level = Console.ReadLine();
                } while (Level != "1" && Level != "2" && Level != "3");

                Console.WriteLine("You Choose Player vs Computer, choose your nick:");
                nick = Console.ReadLine();

                if (Level == "1")
                {
                    nick2 = "EasyBot";
                    AI2 = true;

                }
                else if (Level == "2")
                {
                    nick2 = "HardBot";
                    AIHard = true;

                }
                else if (Level == "3")
                {
                    return Start();
                }

            }
            else if (gameMode == "3")
            {
                nick = "test1";
                nick2 = "test2";
                AI1 = true;
                AI2 = true;
                Console.WriteLine("You Choose TEST");

            }
            else if (gameMode == "4") 
            {
                StatsManager statsManager = new StatsManager();
                statsManager.ShowTopPlayers();
                Console.WriteLine("Press any key to return to menu...");
                Console.ReadKey();
                return Start();
            }

            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Game start in 3");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Game start in 2");
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Game start in 1");
            Thread.Sleep(1000);

            return new GameEngine(this, nick, nick2);

        }
    }
}
