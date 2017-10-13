using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections;
using System.Net;

namespace TheCrozzle
{
    class WordList
    {

        

        //properties
        //public string PathList { get; set; }
        //public string FileName { get; set; }
        //public string DirectoryName { get; set; }
        public List<string> aWordList { get; set; }
        public WordTable Table { get; set; }

        public WordList(string path)
        {
            //PathList = path;
            //FileName = Path.GetFileName(path);
            //DirectoryName = Path.GetDirectoryName(path);
            aWordList = GetWords(path);
            //PopulateTable(path);

        }

        private void PopulateTable(string path)
        {
            Table = new WordTable();
            List<string> words = GetWords(path);

            foreach (string word in words)
            {
                LetterTable letterTable = new LetterTable();

                foreach (char letter in word)
                {
                    if (!letterTable.ContainsKey(letter))
                    {
                        List<string> intersectingWords = new List<string>();

                        foreach (string w in words)
                            if (w.IndexOf(letter) > -1)
                                if (!intersectingWords.Contains(w))
                                    intersectingWords.Add(w);
                        letterTable.Add(letter, intersectingWords);
                    }
                }

                Table.Add(word, letterTable);

            }
        }

        public List<string> GetWords(string path)
        {
            List<string> words = new List<string>();
            StreamReader sr = new StreamReader(path);

            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Split(',');
                foreach (var w in line)
                {
                    words.Add(w);
                }
            }

            return words;

        }


       
    }
}
