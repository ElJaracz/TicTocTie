namespace TicTacToe.GameEngine
{
    internal class Result
    {
        public int Check(char[] cells)
        {
            if (cells[1] == cells[2] && cells[2] == cells[3])
                {
                return 1;
                }
                else if (cells[4] == cells[5] && cells[5] == cells[6])
                {
                    return 1;
                }
                else if (cells[7] == cells[8] && cells[8] == cells[9])
                {
                    return 1;
                }
                else if (cells[1] == cells[4] && cells[4] == cells[7])
                {
                    return 1;
                }
                else if (cells[2] == cells[5] && cells[5] == cells[8])
                {
                    return 1;
                }
                else if (cells[3] == cells[6] && cells[6] == cells[9])
                {
                    return 1;
                }
                else if (cells[1] == cells[5] && cells[5] == cells[9])
                {
                    return 1;
                }
                else if (cells[3] == cells[5] && cells[5] == cells[7])
                {
                    return 1;
                }
                else if (cells[1] != '1' && cells[2] != '2' && cells[3] != '3' && cells[4] != '4' && cells[5] != '5' && cells[6] != '6' && cells[7] != '7' && cells[8] != '8' && cells[9] != '9')
                {
                    return -1;
                }
                else
                {
                    return 0;
                }

            
        }
    }
}
