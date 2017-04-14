using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADAssignment3.Models;

namespace SADAssignment3.KWIC
{
    public class Output
    {
        List<string> noiseWords;
        Alphabetizer alpha;
        NoiseRemover noiseWordChecker;        
        List<KwicOutputModel> output = new List<KwicOutputModel>();

        public Output(Alphabetizer alpha, List<string> noiseWords)
        {
            this.alpha = alpha;
            this.noiseWords = noiseWords;
        }
        public List<KwicOutputModel> Write()
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
                    KwicOutputModel kwicOutput = new KwicOutputModel();
                    kwicOutput.ShiftedLine = shift;
                    kwicOutput.LineIndex = lineCount;
                    output.Add(kwicOutput);
                }                                
            }
            return output;            

        }
    }
}
