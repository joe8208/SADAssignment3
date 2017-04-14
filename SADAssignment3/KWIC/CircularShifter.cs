using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADAssignment3.KWIC
{
    public class CircularShifter
    {
        List<int> wordIndices = new List<int>();
        List<int> lineIndices = new List<int>();

        public int LineIndexLength { get; set; }
        public int CharCoreLength { get; set; }
        

        LineStorage lineStorage;

        int[,] circularShifts;

        public CircularShifter(LineStorage lineStorage)
        {
            this.lineStorage = lineStorage;

            LineIndexLength = lineStorage.GetLineIndexLength();
            CharCoreLength = lineStorage.GetCharCoreLength();
        }

        public void Shift()
        {
            for(int i = 0; i < lineStorage.GetLineIndexLength(); i++)
            {
                wordIndices.Add(lineStorage.GetLineIndex(i));
                lineIndices.Add(i);
                int lastIndex = 0;

                if(i != lineStorage.GetLineIndexLength() - 1)
                {
                    lastIndex = lineStorage.GetLineIndex(i + 1);
                }
                else
                {
                    lastIndex = lineStorage.GetCharCoreLength();
                }

                for(int j = lineStorage.GetLineIndex(i); j < lastIndex; j++)
                {
                    if(lineStorage.GetChar(j) == ' ')
                    {
                        wordIndices.Add(j + 1);
                        lineIndices.Add(i);
                    }
                }
            }
            circularShifts = new int[2, wordIndices.Count];

            for(int i = 0; i < wordIndices.Count; i++)
            {
                circularShifts[0, i] = lineIndices[i];
                circularShifts[1, i] = wordIndices[i];
            }
        }

        public int GetCircularShiftsLength()
        {
            return circularShifts.GetLength(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="indexType">0 for lineIndex, 1 for wordIndex</param>
        /// <param name="index"></param>
        /// <returns></returns>
        public int GetCircularShifts(int indexType, int index)
        {
            return circularShifts[indexType, index];
        }

        public string GetWord(int offSet, int count)
        {
            return lineStorage.GetWord(offSet, count);
        }

        public char GetChar(int index)
        {
            return lineStorage.GetChar(index);
        }

        public int GetLineIndex(int index)
        {
            return lineStorage.GetLineIndex(index);
        }
    }
}
