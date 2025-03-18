using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.Managers;
using TicTacToe.Players;

namespace TicTacToe.GameEngine
{
    class GameEngine
    {
        private bool AI1;
        private bool AI2;
        private bool AIHard;
        private int player;
        private int endgame;
        private char[] cells;
        private Board gameBoard;
        private Result gameResult;
        private int turns;
        private Player gamePlayer1;
        private Player gamePlayer2;
        private AIPlayer aiPlayer;
        private AIPlayerHard aiPlayerHard;
        private FileManager fileManager;
        private StatsManager statsManager;

        public GameEngine(Menu menu, string nick, string nick2)
        {
            AI1 = menu.AI1;
            AI2 = menu.AI2;
            AIHard = menu.AIHard;
            player = 1;
            endgame = 0;
            cells = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            gameBoard = new Board();
            gameResult = new Result();
            gamePlayer1 = new Player(nick);
            gamePlayer2 = new Player(nick2);
            aiPlayer = new AIPlayer();
            aiPlayerHard = new AIPlayerHard();
            turns = 0;
            fileManager = new FileManager(nick, nick2);
            statsManager = new StatsManager();

        }
        public void Go()
        {
            Turn turn = new Turn(gamePlayer1, gamePlayer2, aiPlayer, aiPlayerHard, fileManager);
            do
            {
                gameBoard.View(cells);
                turn.Run(cells, ref player, AI1, AI2, AIHard, ref turns);
                gameBoard.View(cells);
                endgame = gameResult.Check(cells);
            } while (endgame != 1 && endgame != -1);

            if (endgame == 1)
            {

                string winner = (player % 2 != 0) ? gamePlayer2.Nick : gamePlayer1.Nick;
                Console.WriteLine($"{winner} has won in {turns} turns!");
                fileManager.SaveResult(winner, false);
                statsManager.UpdateStats(winner);
            }
            else
            {
                Console.WriteLine("Draw");
                fileManager.SaveResult("", true);


            }

            string rematch;
            Console.WriteLine("Rematch?");
            Console.WriteLine("Write 'y' to rematch, otherwise exit to menu");
            rematch = Console.ReadLine();

            if (rematch == "y")
            {
                ResetGame();
                Go();
            }
            else
            {
                Console.WriteLine("Exit to menu in 3 sec");
                Thread.Sleep(1000);
                Console.WriteLine("Exit to menu in 2 sec");
                Thread.Sleep(1000);
                Console.WriteLine("Exit to menu in 1 sec");
                Thread.Sleep(1000);
                Menu menu = new Menu();
                GameEngine newGame = menu.Start();
                newGame.Go();
            }

        }
        private void ResetGame()
        {
            player = 1;
            endgame = 0;
            turns = 0;
            cells = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
    }
}

