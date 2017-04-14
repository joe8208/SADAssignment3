using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADAssignment3.KWIC
{
    public class Alphabetizer
    {
        int[][] alphabetized;

        CircularShifter circularShifter;

        public int AlphabetizedLength { get; set; }

        public int LineIndexLength { get; set; }

        public int CharCoreLength { get; set; }

        public Alphabetizer(CircularShifter circularShifter)
        {
            this.circularShifter = circularShifter;
            LineIndexLength = circularShifter.LineIndexLength;
            CharCoreLength = circularShifter.CharCoreLength;
        }

        public int GetAlphabetized(int row, int col)
        {
            return alphabetized[row][col];
        }

        public string GetWord(int offset, int count)
        {
            return circularShifter.GetWord(offset, count);
        }

        public char GetChar(int index)
        {
            return circularShifter.GetChar(index);
        }

        public int GetLineIndex(int index)
        {
            return circularShifter.GetLineIndex(index);
        }

        
        public void Alphabetize()
        {
            alphabetized = new int[2][];
            alphabetized[0] = new int[circularShifter.GetCircularShiftsLength()];
            alphabetized[1] = new int[circularShifter.GetCircularShiftsLength()];
            AlphabetizedLength = alphabetized[0].Length;

            int alphabetizedCount = 0;
            int low, mid, high = 0;
            
            for (int i = 0; i < alphabetized[0].Length; i++)
            {
                int lineCount = circularShifter.GetCircularShifts(0, i);
                int shiftBegin = circularShifter.GetCircularShifts(1, i);

                int lineBegin = circularShifter.GetLineIndex(lineCount);
                int lineEnd = 0;
                if (lineCount == circularShifter.LineIndexLength - 1)
                {
                    lineEnd = circularShifter.CharCoreLength;
                }
                else
                {
                    lineEnd = circularShifter.GetLineIndex(lineCount + 1);
                }


                string shift = "";

                if (lineBegin != shiftBegin)
                {
                    shift += circularShifter.GetWord(shiftBegin, lineEnd - shiftBegin);
                    shift += " ";
                    shift += circularShifter.GetWord(lineBegin, shiftBegin - lineBegin - 1);
                }
                else
                {
                    shift += circularShifter.GetWord(lineBegin, lineEnd - lineBegin);
                }


                // binary search
                low = 0;
                high = alphabetizedCount - 1;

                while(low <= high)
                {
                    mid = (low + high) / 2;

                    int midLineCount = alphabetized[0][mid];
                    int midShiftBegin = alphabetized[1][mid];
                    int midLineBegin = circularShifter.GetLineIndex(midLineCount);
                    int midLineEnd = 0;

                    if (midLineCount == circularShifter.LineIndexLength - 1)
                    {
                        midLineEnd = circularShifter.CharCoreLength;
                    }
                    else
                    {
                        midLineEnd = circularShifter.GetLineIndex(midLineCount + 1);
                    }

                    string midLine = "";
                    if (midLineBegin != midShiftBegin)
                    {
                        midLine += circularShifter.GetWord(midShiftBegin, midLineEnd - midShiftBegin);
                        midLine += " ";
                        midLine += circularShifter.GetWord(midLineBegin, midShiftBegin - midLineBegin - 1);
                    }
                    else
                    {
                        midLine += circularShifter.GetWord(midLineBegin, midLineEnd - midLineBegin);
                    }

                    // comparer
                    //int compared = shift.CompareTo(midLine);
                    int compared = CustomComparable(shift, midLine);


                    if (compared > 0)
                        low = mid + 1;
                    else if (compared < 0)
                        high = mid - 1;
                    else
                    {
                        low = mid;
                        high = mid - 1;
                    }

                    
                }
                    Array.Copy(alphabetized[0], low, alphabetized[0], low + 1, alphabetizedCount - low);
                    Array.Copy(alphabetized[1], low, alphabetized[1], low + 1, alphabetizedCount - low);
                    alphabetized[0][low] = lineCount;
                    alphabetized[1][low] = shiftBegin;
                    alphabetizedCount++;

            }
        }

        int CustomComparable(string x, string y)
        {
            // make sorter sort lower case characters first then uppercase characters
            // take line conver it into a array of charaters and compare to the second string if it is less or greater on the sort order.
            int maxStringLength = 0;

            if (x.Length <= y.Length)
                maxStringLength = x.Length;
            else
            {
                maxStringLength = y.Length;
            }

            for (int i = 0; i < maxStringLength; i++)
            {
                char a = x[i];
                char b = y[i];

                if (a.ToString().ToLower() == b.ToString().ToLower())
                {
                    if (a == b)
                    {
                        if (i + 1 == maxStringLength)
                        {
                            if (x.Length < y.Length)
                                return -1;
                            else
                                return 1;
                        }
                    }
                    else
                    {

                        if (a.ToString().ToLower() == b.ToString())
                        {
                            return 1;
                        }
                        else if (a.ToString().ToLower() != b.ToString())
                        {
                            return -1;
                        }
                    }

                }
                else
                {
                    return string.Compare(a.ToString(), b.ToString());
                }
            }
            return 0;
        }
        
    }
}
