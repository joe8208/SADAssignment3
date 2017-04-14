using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADAssignment3.KWIC
{
    public class Output
    {
        List<string> noiseWords;
        Alphabetizer alpha;
        NoiseRemover noiseWordChecker;
        List<string> output = new List<string>();

        public Output(Alphabetizer alpha, List<string> noiseWords)
        {
            this.alpha = alpha;
            this.noiseWords = noiseWords;
        }
        public List<string> Write()
        {
            noiseWordChecker = new NoiseRemover(noiseWords);

            for (int i = 0; i < alpha.AlphabetizedLength; i++)
            {
                int lineCount = alpha.GetAlphabetized(0, i);
                int shiftBegin = alpha.GetAlphabetized(1, i);
                int lineBegin = alpha.GetLineIndex(lineCount);

                int lineEnd = 0;

                if (lineCount == alpha.LineIndexLength - 1)
                {
                    lineEnd = alpha.CharCoreLength;
                }
                else
                {
                    lineEnd = alpha.GetLineIndex(lineCount + 1);
                }
                
                string shift = "";

                if (lineBegin != shiftBegin)
                {
                    shift += alpha.GetWord(shiftBegin, lineEnd - shiftBegin);
                    shift += " ";
                    shift += alpha.GetWord(lineBegin, shiftBegin - lineBegin - 1);
                }
                else
                {
                    shift += alpha.GetWord(lineBegin, lineEnd - lineBegin);
                }

                // check for noise words
                
                if (!noiseWordChecker.HasNoiseWords(shift))
                {
                    output.Add(shift);
                }                                
            }
            return output;            

        }
    }
}
