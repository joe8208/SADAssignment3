using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADAssignment3.KWIC
{
    public class NoiseRemover
    {
        List<string> noiseWords;

        public NoiseRemover(List<string> noiseWords)
        {
            this.noiseWords = noiseWords;
        }

        public bool HasNoiseWords(string input)
        {
            // iterate and remove any lines that start with any of the noise words.           
            
            string[] words = input.Split(new char[] { ' ' });

            // check to see if the first word in line matches a noise word

            foreach (string noiseWord in noiseWords)
            {
                if (words[0].ToLower() == noiseWord.ToLower())
                {
                    return true;
                }
            }
            return false;            
        }
    }
}
