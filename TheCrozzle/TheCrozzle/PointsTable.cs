using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheCrozzle
{
    class PointsTable 
    {
        public Dictionary<char, int> PointsPerLetter { get; set; }

        public PointsTable()
        {
            PointsPerLetter = GetPoints();
        }

        public Dictionary<char, int> GetPoints()
        {
            List<string> points = new List<string>();
            PointsPerLetter = new Dictionary<char, int>();

            StreamReader sr = new StreamReader(@"C:\Users\kelli\Desktop\pointsTable.txt");
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine().Split(',');
                foreach (var w in line)
                {
                    points.Add(w);
                }
            }

            foreach(var l in points)
            {
                var k = l.Substring(0, 1);
                var v = l.Substring(2);
                PointsPerLetter.Add(Convert.ToChar(k), Convert.ToInt16(v));
            }

            return PointsPerLetter;

        }
    }
}
