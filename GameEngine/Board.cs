using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.GameEngine
{
    internal class Board
    {
        public void View(char[] cells)
            
        {
            Console.Clear();
            Console.WriteLine("***************");
            Console.WriteLine("*    |   |    *");
            Console.WriteLine("*  {0} | {1} | {2}  *", cells[1], cells[2], cells[3]);
            Console.WriteLine("* ---|---|--- *");
            Console.WriteLine("*  {0} | {1} | {2}  *", cells[4], cells[5], cells[6]);
            Console.WriteLine("* ---|---|--- *");
            Console.WriteLine("*  {0} | {1} | {2}  *", cells[7], cells[8], cells[9]);
            Console.WriteLine("*    |   |    *");
            Console.WriteLine("***************");
        }
    }
}
