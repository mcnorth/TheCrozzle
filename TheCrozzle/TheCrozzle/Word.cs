using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCrozzle
{
    class Word
    {
        public string Element { get; set; }
        public int ScoreOfWord { get; set; }
        public WordTable IntersectingWords { get; set; }
        //public Dictionary<Coordinate, char> LettersInWordPositions { get; set; }
        public bool IsHorizontal { get; set; }
        public bool IsVertical { get; set; }
        public bool IsAdded { get; set; }
        public bool IsValid { get; set; }
        public char[] LettersInWordArray { get; set; }
        public List<LettersInWord> LettersInWordPositions { get; set; }
        public int IndexOfIntersectingLetter { get; set; }
        public List<char> IntersectingLetters { get; set; }


        public Word(string element, WordList list)
        {
            Element = element;
            IntersectingWords = GetIntersectingWords(list);
            ScoreOfWord = GetScoreOfWord();
            LettersInWordArray = GetLettersInWord(element);
            LettersInWordPositions = GetLettersInWordPositions(element);
            IsHorizontal = false;
            IsVertical = false;
            IsAdded = false;
            IsValid = false;
            IndexOfIntersectingLetter = 0;
            IntersectingLetters = new List<char>();

        }

        private char[] GetLettersInWord(string element)
        {
            char[] letters = element.ToCharArray();

            return letters;

        }

        private List<LettersInWord> GetLettersInWordPositions(string element)
        {
            List<LettersInWord> lettersList = new List<LettersInWord>();

            char[] letters = GetLettersInWord(element);

            for(int i = 0; i < letters.Length; i++)
            {
                LettersInWord w = new LettersInWord(i, letters[i]);
                lettersList.Add(w);
            }

            return lettersList;
        }

        private int GetScoreOfWord()
        {
            PointsTable pt = new PointsTable();
            int score = 0;
            var letters = IntersectingWords.Values.First();

            foreach(var key in letters)
            {
                var letter = key.Key;

                foreach(var let in pt.PointsPerLetter)
                {
                    if(letter == let.Key)
                    {
                        score = score + let.Value;
                    }
                }


            }

            return score;
        }

        private WordTable GetIntersectingWords(WordList list)
        {
            IntersectingWords = new WordTable();

            LetterTable letterTable = new LetterTable();

            foreach (char letter in Element)
            {
                if (!letterTable.ContainsKey(letter))
                {
                    List<string> intersectingWords = new List<string>();

                    foreach (string w in list.aWordList)
                        if (w.IndexOf(letter) > -1)
                            if (!intersectingWords.Contains(w))
                                intersectingWords.Add(w);
                    letterTable.Add(letter, intersectingWords);
                }
            }

            IntersectingWords.Add(Element, letterTable);

            return IntersectingWords;

        }

    }
}
