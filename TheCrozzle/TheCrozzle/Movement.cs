using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrozzle
{
    class Movement
    {
        public int LeftOfLetter { get; set; }
        public int RightOfLetter { get; set; }
        public int AboveLetter { get; set; }
        public int BelowLetter { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int AboveLetterPlusSpace { get; set; }
        public int BelowLetterPlusSpace { get; set; }
        public int LeftOfLetterPlusSpace { get; set; }
        public int RightOfLetterPlusSpace { get; set; }
        public bool IsValid { get; set; }

        public Movement(int row, int col)
        {
            StartX = row;
            StartY = col;
            LeftOfLetter = StartY - 1;  //movement points 
            RightOfLetter = StartY + 1;
            AboveLetter = StartX - 1;
            BelowLetter = StartX + 1;
            AboveLetterPlusSpace = AboveLetter - 1;
            BelowLetterPlusSpace = BelowLetter + 1;
            LeftOfLetterPlusSpace = LeftOfLetter - 1;
            RightOfLetterPlusSpace = RightOfLetter + 1;
            IsValid = false;

        }

        
    }
}
