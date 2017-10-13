using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrozzle
{
    class Coordinate
    {
        public int Row { get; set; }
        public int Column { get; set; }

        public Coordinate(int row, int col)
        {
            Row = row;
            Column = col;
        }
    }
}
