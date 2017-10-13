using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrozzle
{
    class CrozzleGrid
    {
        public char [,] Grid { get; set; }
        public WordList ListOfNames { get; set; }
        public PointsTable Ptable { get; set; }
        public List<Word> ListOfNamesInGrid { get; set; }
        public Word LastInsertedWord { get; set; }
        public List<string> ListOfNamesInGridString { get; set; }
        public List<Word> ListOfNamesInGridCopy { get; set; }
        public int Counter { get; set; }
        public bool Next { get; set; }
        public int Score { get; set; }
        public List<char> AllIntersectingLettersInGrid { get; set; }



        public CrozzleGrid(WordList list)
        {
            Grid = CreateGrid();
            ListOfNames = list;
            Ptable = new PointsTable();
            ListOfNamesInGrid = new List<Word>();
            ListOfNamesInGridString = new List<string>();
            ListOfNamesInGridCopy = new List<Word>();
            Counter = 0;
            Next = false;
            Score = 0;
            AllIntersectingLettersInGrid = new List<char>();
        }

        public char[,] MoreWords()
        {
            Counter = 0;
            foreach(var obj in ListOfNamesInGrid)
            {
                var lettersInWord = obj.LettersInWordPositions;
                var name = obj.IntersectingWords.First();
                var intersectingWords = name.Value;

                foreach (var letterInExistingWord in lettersInWord)
                {
                    var letterInExistingWordIndex = letterInExistingWord.Index;
                    var letterInExistingWordLetter = letterInExistingWord.Letter;
                    var letterInExistingWordCoords = letterInExistingWord.Coords;

                    foreach (var let in intersectingWords)
                    {
                        var k = let.Key;
                        var intersectingWordList = let.Value.OrderByDescending(i => i.Length).ToList();

                        if (k == letterInExistingWordLetter)
                        {
                            foreach (var nameInList in intersectingWordList)
                            {
                                if (ListOfNamesInGridString.Contains(nameInList))
                                {
                                    continue;
                                }
                                else
                                {
                                    Word nme = new Word(nameInList, ListOfNames);
                                    nme.IntersectingLetters.Add(k);
                                    CheckWord(nme, letterInExistingWord, obj);

                                    if (nme.IsValid == true)
                                    {
                                        AddWordToGrid(nme, letterInExistingWordCoords);
                                        if (nme.IsAdded == true)
                                        {
                                            foreach (var l in nme.IntersectingLetters)
                                            {
                                                AllIntersectingLettersInGrid.Add(l);
                                            }

                                            ListOfNamesInGridCopy.Add(nme);
                                            ListOfNamesInGridString.Add(nme.Element);
                                            LastInsertedWord = nme;
                                            ListOfNames.aWordList.Remove(nme.Element);
                                            Counter = 1;

                                            
                                        }
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }
                            }
                        }
                    }
                }
            }

            if(ListOfNamesInGridCopy.Count > 0)
            {
                foreach(var ele in ListOfNamesInGridCopy)
                {
                    ListOfNamesInGrid.Add(ele);
                }

                ListOfNamesInGridCopy.Clear();
                Next = true;
            }
            else
            {
                Next = false;
            }
            
            

            return Grid;
        }

        public char[,] AddFirstWord()
        {
            List<Word> highestWordList = new List<Word>();

            foreach(var str in ListOfNames.aWordList)
            {
                Word w = new Word(str, ListOfNames);
                highestWordList.Add(w);
            }

            var highestWordListSorted = highestWordList.OrderByDescending(i => i.ScoreOfWord).ToList();

            var highestWord = highestWordListSorted[0];

            //Word w = new Word(highestWordList[0], ListOfNames);
            var arrayOfLetters = highestWord.LettersInWordArray;
            int startX = 1;
            int startY = 1;

            for(int i = 0; i < arrayOfLetters.Length; i++)
            {
                Grid[startX, startY] = arrayOfLetters[i];
                Coordinate c = new Coordinate(startX, startY);
                int index = i;

                foreach(var obj in highestWord.LettersInWordPositions)
                {
                    if(obj.Index == i)
                    {
                        obj.Coords = c;
                    }
                }

                highestWord.IsHorizontal = true;
                startY = startY + 1;
            }
            
            ListOfNames.aWordList.Remove(highestWord.Element);
            ListOfNamesInGrid.Add(highestWord);
            ListOfNamesInGridString.Add(highestWord.Element);
            LastInsertedWord = highestWord;
            Counter = 1;

            return Grid;
        }
 

        public char[,] AddWord()
        {
            Counter = 0;
            var lettersInWord = LastInsertedWord.LettersInWordPositions;
            var name = LastInsertedWord.IntersectingWords.First();
            var intersectingWords = name.Value;
            //var longestWordList = ListOfNames.aWordList.OrderByDescending(i => i.Length).ToList();

            foreach (var letterInExistingWord in lettersInWord)
            {
                var letterInExistingWordIndex = letterInExistingWord.Index;
                var letterInExistingWordLetter = letterInExistingWord.Letter;
                var letterInExistingWordCoords = letterInExistingWord.Coords;


                foreach (var let in intersectingWords)
                {
                    var k = let.Key;
                    var intersectingWordList = let.Value.OrderByDescending(i => i).ToList();

                    
                    if (k == letterInExistingWordLetter)
                    {
                        foreach (var nameInList in intersectingWordList)
                        {
                            if (ListOfNamesInGridString.Contains(nameInList))
                            {
                                continue;
                            }
                            else
                            {
                                Word nme = new Word(nameInList, ListOfNames);
                                nme.IntersectingLetters.Add(k);
                                CheckWord(nme, letterInExistingWord, LastInsertedWord);

                                if (nme.IsValid == true)
                                {
                                    AddWordToGrid(nme, letterInExistingWordCoords);
                                    if (nme.IsAdded == true)
                                    {
                                        foreach(var l in nme.IntersectingLetters)
                                        {
                                            AllIntersectingLettersInGrid.Add(l);
                                        }
                                        ListOfNamesInGrid.Add(nme);
                                        ListOfNamesInGridString.Add(nme.Element);
                                        LastInsertedWord = nme;
                                        ListOfNames.aWordList.Remove(nme.Element);
                                        Counter = 1;
                                        
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            
                        }

                    }
                }

            }

            

            return Grid;

        }

        public Word AddWordToGrid(Word name, Coordinate letterInExistingWordCoords)
        {
            if(name.IsVertical == true)
            {
                var startX = letterInExistingWordCoords.Row - name.IndexOfIntersectingLetter;
                var startY = letterInExistingWordCoords.Column;
                var bRow = startX - 1;
                var eRow = startX + name.LettersInWordArray.Length;

                if(Grid[bRow, startY] == '\0' || Grid[bRow, startY] == '*')
                {
                    if(Grid[eRow, startY] == '\0' || Grid[eRow, startY] == '*')
                    {
                        foreach (var letter in name.LettersInWordPositions)
                        {
                            Grid[startX, startY] = letter.Letter;
                            Coordinate coord = new Coordinate(startX, startY);
                            letter.Coords = coord;
                            startX = startX + 1;
                        }
                    }
                    else
                    {
                        name.IsAdded = false;
                        return name;
                    }
                }
                else
                {
                    name.IsAdded = false;
                    return name;
                }

                
                name.IsAdded = true;
                return name;
            }

            if(name.IsHorizontal == true)
            {
                var startX = letterInExistingWordCoords.Row;
                var startY = letterInExistingWordCoords.Column - name.IndexOfIntersectingLetter;
                var bCol = startY - 1;
                var eCol = startY + name.LettersInWordArray.Length;

                if (Grid[startX, bCol] == '\0' || Grid[startX, bCol] == '*')
                {
                    if (Grid[startX, eCol] == '\0' || Grid[startX, eCol] == '*')
                    {
                        foreach (var letter in name.LettersInWordPositions)
                        {
                            Grid[startX, startY] = letter.Letter;
                            Coordinate coord = new Coordinate(startX, startY);
                            letter.Coords = coord;
                            startY = startY + 1;
                        }
                    }
                    else
                    {
                        name.IsAdded = false;
                        return name;
                    }
                }
                else
                {
                    name.IsAdded = false;
                    return name;
                }


                name.IsAdded = true;
                return name;                

            }

            return name;
        }

        public Word CheckWord(Word name, LettersInWord letterInExistingWord, Word lastWord)
        {
            if(lastWord.IsHorizontal == true)
            {
                AddingToHorizonatalWord(name, letterInExistingWord, lastWord);
                return name;
            }
            else
            {
                AddingToVerticalWord(name, letterInExistingWord, lastWord);
                return name;
            }
            //return name;
        }       

        public Word AddingToHorizonatalWord(Word name, LettersInWord letterInExistingWord, Word lastWord)
        {
            Movement move = new Movement(letterInExistingWord.Coords.Row, letterInExistingWord.Coords.Column);
            
            name.IndexOfIntersectingLetter = Array.IndexOf(name.LettersInWordArray, letterInExistingWord.Letter);
            
            string aboveArray = name.Element.Substring(0, name.IndexOfIntersectingLetter);
            string belowArray = name.Element.Substring(name.IndexOfIntersectingLetter + 1);

            if(aboveArray.Length > 0 && belowArray.Length > 0)
            {
                for (int i = aboveArray.Length - 1; i > -1; i--)
                {
                    ValidateAddingToHorizontalWord.ValidateAboveOne(move, Grid, aboveArray[i], name);
                    if (move.IsValid == true)
                    {
                        name.IsValid = true;
                        name.IsVertical = true;
                        move.AboveLetter--;
                    }
                    else
                    {
                        name.IsValid = false;
                        return name;
                    }

                }

                for (int i = 0; i < belowArray.Length; i++)
                {
                    ValidateAddingToHorizontalWord.ValidateBelowOne(move, Grid, belowArray[i], name);
                    if (move.IsValid == true)
                    {
                        name.IsValid = true;
                        name.IsVertical = true;
                        move.BelowLetter++;

                    }
                    else
                    {
                        name.IsValid = false;
                        return name;
                    }
                }
            }

            if(aboveArray.Length == 0 && belowArray.Length > 0)
            {
                
                for(int i = 0; i < belowArray.Length; i++)
                {
                    ValidateAddingToHorizontalWord.ValidateBelowOne(move, Grid, belowArray[i], name);
                    if (move.IsValid == true)
                    {
                        name.IsValid = true;
                        name.IsVertical = true;
                        move.BelowLetter++;

                    }
                    else
                    {
                        name.IsValid = false;
                        return name;
                    }
                }
            }

            if(aboveArray.Length > 0 && belowArray.Length == 0)
            {
                for (int i = aboveArray.Length - 1; i > -1; i--)
                {
                    ValidateAddingToHorizontalWord.ValidateAboveOne(move, Grid, aboveArray[i], name);
                    if (move.IsValid == true)
                    {
                        name.IsValid = true;
                        name.IsVertical = true;
                        move.AboveLetter--;
                    }
                    else
                    {
                        name.IsValid = false;
                        return name;
                    }
                }
            }
            
            
            return name;
        }

        public Word AddingToVerticalWord(Word name, LettersInWord letterInExistingWord, Word lastWord)
        {
            Movement move = new Movement(letterInExistingWord.Coords.Row, letterInExistingWord.Coords.Column);
            name.IndexOfIntersectingLetter = Array.IndexOf(name.LettersInWordArray, letterInExistingWord.Letter);

            
            string leftArray = name.Element.Substring(0, name.IndexOfIntersectingLetter);
            string rightArray = name.Element.Substring(name.IndexOfIntersectingLetter + 1);

            
            if (leftArray.Length > 0 && rightArray.Length > 0)
            {
                //check left hand side of word
                for (int i = leftArray.Length - 1; i > -1; i--)
                {
                    ValidateAddingToVerticalWord.ValidateLeftOne(move, Grid, leftArray[i], name);
                    if (move.IsValid == true)
                    {
                        name.IsValid = true;
                        name.IsHorizontal = true;
                        move.LeftOfLetter--;
                    }
                    else
                    {
                        name.IsValid = false;
                        return name;
                    }

                }

                //check right hand side of word
                for (int i = rightArray.Length - 1; i > -1; i--)
                {
                    ValidateAddingToVerticalWord.ValidateRightOne(move, Grid, rightArray[i], name);
                    if (move.IsValid == true)
                    {
                        name.IsValid = true;
                        name.IsHorizontal = true;
                        move.RightOfLetter++;
                    }
                    else
                    {
                        name.IsValid = false;
                        return name;
                    }
                }
            }

            if (leftArray.Length == 0 && rightArray.Length > 0)
            {
                for (int i = rightArray.Length - 1; i > -1; i--)
                {
                    ValidateAddingToVerticalWord.ValidateRightOne(move, Grid, rightArray[i], name);
                    if (move.IsValid == true)
                    {
                        name.IsValid = true;
                        name.IsHorizontal = true;
                        move.RightOfLetter++;
                    }
                    else
                    {
                        name.IsValid = false;
                        return name;
                    }
                }
                
            }

            if (leftArray.Length > 0 && rightArray.Length == 0)
            {
                for (int i = leftArray.Length - 1; i > -1; i--) 
                {
                    ValidateAddingToVerticalWord.ValidateLeftOne(move, Grid, leftArray[i], name);
                    if (move.IsValid == true)
                    {
                        name.IsValid = true;
                        name.IsHorizontal = true;
                        move.LeftOfLetter--;
                    }
                    else
                    {
                        name.IsValid = false;
                        return name;
                    }
                }
            }

            return name;
        }

        public int GetScore()
        {
            Score = Score + (ListOfNamesInGridString.Count * 10);

            foreach (var letter in AllIntersectingLettersInGrid)
            {
                foreach (var obj in Ptable.PointsPerLetter)
                {
                    var charKey = obj.Key;
                    var charVal = obj.Value;

                    if (letter == charKey)
                    {
                        Score = Score + charVal;
                    }
                }
            }


            return Score;

        }

        public string DisplayGrid(CrozzleGrid game)
        {
            char[,] grid = game.Grid;
            string crozzleDisplay = "";
            string style = "<style> table, td { border: 1px solid black; border-collapse: collapse; } td { width:24px; height:18px; text-align: center; } </style>";

            style += @"<style>
                       .empty { background-color: #777777; }
                       .nonempty { background-color: white; }
                       .border { background-color: black; }
                       </style>";

            crozzleDisplay += @"<!DOCTYPE html><html><head>";
            crozzleDisplay += style;
            crozzleDisplay += @"</head><body>";
            crozzleDisplay += @"<table>";

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                crozzleDisplay += @"<tr>";

                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (grid[i, j] == '*')
                    {
                        crozzleDisplay += @"<td hidden class=""border""></td>";
                    }
                    else if (grid[i, j] == '\0')
                    {
                        crozzleDisplay += @"<td class=""empty""></td>";
                    }
                    else
                    {
                        crozzleDisplay += @"<td class=""nonempty"">" + grid[i, j] + @"</td>";
                    }
                }
                crozzleDisplay += @"</tr>";
            }
            crozzleDisplay += @"</table>";

            //crozzleHTML += @"<p>Score = " + game.Score + @"</p>";

            //if (game.Counter == 0)
            //{
            //    crozzleHTML += @"<p>Cannot add any more words.</p>";
            //}

            crozzleDisplay += @"</body></html>";

            return crozzleDisplay;
        }

        public char[,] CreateGrid()
        {
            var rows = 11;
            var cols = 16;

            char[,] grid = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                if (i == 0 || i == rows - 1)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        grid[i, j] = '*';
                    }
                }

                if (i >= 1 && i <= rows - 2)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        if (j == 0 || j == cols - 1)
                        {
                            grid[i, j] = '*';
                        }
                        else if (j >= 1 && j <= cols - 2)
                        {
                            grid[i, j] = '\0';
                        }
                    }
                }

            }


            return grid;

        }
    }
}
