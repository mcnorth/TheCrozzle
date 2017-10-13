using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheCrozzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void wbGameGrid_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void loadWordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = openFileDialog1.ShowDialog();
            WordList wList = new WordList(openFileDialog1.FileName);
            if (res == DialogResult.OK)
            {
                OpenCrozzle(wList);
                
            }
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void OpenCrozzle(WordList wList)
        {

            CrozzleGrid aGrid = new CrozzleGrid(wList);
            aGrid.AddFirstWord();
            aGrid.AddWord();

            Recursive(aGrid);
            aGrid.MoreWords();
            NextRecursive(aGrid);
            aGrid.GetScore();
            

            string result = aGrid.DisplayGrid(aGrid);

            wbGameGrid.DocumentText = result;
            lblScore.Text = "Score: " + aGrid.Score;
        }

        private CrozzleGrid Recursive(CrozzleGrid aGrid)
        {
            if(aGrid.Counter == 0)
            {
                return aGrid;
            }
            else
            {
                aGrid.AddWord();
            }

            return Recursive(aGrid);
        }

        private CrozzleGrid NextRecursive(CrozzleGrid aGrid)
        {
            if (aGrid.Counter == 0 && aGrid.Next == false)
            {
                return aGrid;
            }
            else
            {
                aGrid.MoreWords();
            }

            return NextRecursive(aGrid);
        }
    }
}
