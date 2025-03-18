using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Players
{
    internal interface IPlayer
    {
        public int GetMove(char[]cells);
    }
}
