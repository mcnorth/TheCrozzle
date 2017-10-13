using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrozzle
{
    class ValidateAddingToHorizontalWord
    {

        public static bool ValidateAboveOne(Movement move, char[,] Grid, char letter, Word name)
        {
            if (Grid[move.AboveLetter, move.StartY] == '\0' || Grid[move.AboveLetter, move.StartY] == '*')
            {
                ValidateAboveTwo(move, Grid, letter, name);
                if (move.IsValid == true)
                {
                    return move.IsValid = true;
                }
                else
                {
                    return move.IsValid = false;
                }


            }
            else if (Grid[move.AboveLetter, move.StartY] == letter)
            {
                name.IntersectingLetters.Add(letter);
                return move.IsValid = true;
            }
            else
            {
                return move.IsValid = false;
            }


        }


        public static bool ValidateAboveTwo(Movement move, char[,] Grid, char letter, Word name)
        {
            if (Grid[move.AboveLetter, move.LeftOfLetter] == '\0' && Grid[move.AboveLetter, move.RightOfLetter] == '\0')
            {
                return move.IsValid = true;
            }
            else if (Grid[move.AboveLetter, move.LeftOfLetter] == '*' && Grid[move.AboveLetter, move.RightOfLetter] == '\0')
            {
                return move.IsValid = true;
            }
            else if (Grid[move.AboveLetter, move.LeftOfLetter] == '\0' && Grid[move.AboveLetter, move.RightOfLetter] == '*')
            {
                return move.IsValid = true;
            }
            else
            {
                return move.IsValid = false;
            }
        }

        //check the actual square
        public static bool ValidateBelowOne(Movement move, char[,] Grid, char letter, Word name)
        {
            if (Grid[move.BelowLetter, move.StartY] == '\0' || Grid[move.BelowLetter, move.StartY] == '*')
            {
                ValidateBelowTwo(move, Grid, letter, name);
                if (move.IsValid == true)
                {
                    return move.IsValid = true;
                }
                else
                {
                    return move.IsValid = false;
                }

            }
            else if(Grid[move.BelowLetter, move.StartY] == letter)
            {
                name.IntersectingLetters.Add(letter);
                return move.IsValid = true;
            }
            else
            {
                return move.IsValid = false;
            }
        }

        //check either side of the actual square
        public static bool ValidateBelowTwo(Movement move, char[,] Grid, char letter, Word name)
        {
            if (Grid[move.BelowLetter, move.LeftOfLetter] == '\0' && Grid[move.BelowLetter, move.RightOfLetter] == '\0')
            {
                return move.IsValid = true;
            }
            else if (Grid[move.BelowLetter, move.LeftOfLetter] == '*' && Grid[move.BelowLetter, move.RightOfLetter] == '\0')
            {
                return move.IsValid = true;
            }
            else if (Grid[move.BelowLetter, move.LeftOfLetter] == '\0' && Grid[move.BelowLetter, move.RightOfLetter] == '*')
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
