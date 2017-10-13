using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrozzle
{
    class Validate
    {

        public static bool ValidateGridSquare(int row, int col, char letter, char[,] Grid)
        {

            if (Grid[row, col] == '\0' || Grid[row, col] == letter)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        

        public static bool ValidateSquaresAroundGridSquare(int row, int col, char[,] Grid)
        {
            if (Grid[row, col] == '\0' || Grid[row, col] == '*')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
