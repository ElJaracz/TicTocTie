using System.ComponentModel.Design;
using TicTacToe.GameEngine;

class Program
{
    static void Main()
    {
        Welcome.View();
        while (true)
        {

            Menu menu = new Menu();
            GameEngine game = menu.Start();
            game.Go();
        }
    }
}