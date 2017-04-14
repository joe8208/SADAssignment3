using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADAssignment3.KWIC
{
    public class LineStorage
    {        
        char[] charCore;
        int[] lineIndex;
        List<int> lineIndices = new List<int>();
        string lines = "";
        
        public LineStorage()
        {
            lineIndex = new int[0];
            // initializing charArray
            charCore = lines.ToCharArray();
        }

        public void AddLine(string line)
        {
            lines += line;

            lineIndices.Add(lines.Length);
        }

        /// <summary>
        /// Sets up the char core with the data from input data
        /// </summary>
        public void SetCharCore()
        {
            charCore = lines.ToCharArray();
            lineIndex = new int[lineIndices.Count];
                      

            for(int i = 0; i < lineIndices.Count; i++)
            {
                if (i == 0)
                    lineIndex[i] = 0;
                else
                {
                    // pulling in the index of the location directly behind the prior insert
                    // so it is the beginning of the next read in line
                    lineIndex[i] = lineIndices[i - 1];
                }

            }
        }

        public int GetLineIndexLength()
        {
            return lineIndex.Length;
        }
        
        public int GetLineIndex(int i)
        {
            return lineIndex[i];
        }

      
        public int GetCharCoreLength()
        {
            return charCore.Length;
        }

        public char GetChar(int i)
        {
            return charCore[i];
        }

        public string GetWord(int offSet, int count)
        {
            return new string(charCore, offSet, count);
        }
    }
}
