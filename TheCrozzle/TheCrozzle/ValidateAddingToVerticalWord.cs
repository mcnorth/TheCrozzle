using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrozzle
{
    class ValidateAddingToVerticalWord
    {
        public static bool ValidateLeftOne(Movement move, char[,] Grid, char letter, Word name)
        {
            if (Grid[move.StartX, move.LeftOfLetter] == '\0' || Grid[move.StartX, move.LeftOfLetter] == '*')
            {
                ValidateLeftTwo(move, Grid, letter, name);
                if(move.IsValid == true)
                {
                    return move.IsValid = true;
                }
                else
                {
                    return move.IsValid = false;
                }
                
            }
            else if (Grid[move.StartX, move.LeftOfLetter] == letter)
            {
                name.IntersectingLetters.Add(letter);
                return move.IsValid = true;
            }
            else
            {
                return move.IsValid = false;
            }


        }


        public static bool ValidateLeftTwo(Movement move, char[,] Grid, char letter, Word name)
        {
            if (Grid[move.BelowLetter, move.LeftOfLetter] == '\0' && Grid[move.AboveLetter, move.LeftOfLetter] == '\0')
            {
                return move.IsValid = true;
            }
            else if (Grid[move.BelowLetter, move.LeftOfLetter] == '*' && Grid[move.AboveLetter, move.LeftOfLetter] == '\0')
            {
                return move.IsValid = true;
            }
            else if (Grid[move.BelowLetter, move.LeftOfLetter] == '\0' && Grid[move.AboveLetter, move.LeftOfLetter] == '*')
            {
                return move.IsValid = true;
            }
            else
            {
                return move.IsValid = false;
            }
        }

        public static bool ValidateRightOne(Movement move, char[,] Grid, char letter, Word name)
        {
            if (Grid[move.StartX, move.RightOfLetter] == '\0' || Grid[move.StartX, move.RightOfLetter] == '*')
            {
                ValidateRightTwo(move, Grid, letter, name);
                if (move.IsValid == true)
                {
                    return move.IsValid = true;
                }
                else
                {
                    return move.IsValid = false;
                }

            }
            else if (Grid[move.StartX, move.RightOfLetter] == letter)
            {
                name.IntersectingLetters.Add(letter);
                return move.IsValid = true;
            }
            else
            {
                return move.IsValid = false;
            }
        }


        public static bool ValidateRightTwo(Movement move, char[,] Grid, char letter, Word name)
        {
            if (Grid[move.BelowLetter, move.RightOfLetter] == '\0' && Grid[move.AboveLetter, move.RightOfLetter] == '\0')
            {
                return move.IsValid = true;
            }
            else if (Grid[move.BelowLetter, move.RightOfLetter] == '*' && Grid[move.AboveLetter, move.RightOfLetter] == '\0')
            {
                return move.IsValid = true;
            }
            else if (Grid[move.BelowLetter, move.RightOfLetter] == '\0' && Grid[move.AboveLetter, move.RightOfLetter] == '*')
            {
                return move.IsValid = true;
            }
            else
            {
                return move.IsValid = false;
            }
        }
    }
}
