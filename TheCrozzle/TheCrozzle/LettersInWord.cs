using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrozzle
{
    class LettersInWord
    {
        public int Index { get; set; }
        public Coordinate Coords { get; set; }
        public char Letter { get; set; }

        public LettersInWord(int index, char letter)
        {
            Index = index;
            Letter = letter;
        }

    }
}
