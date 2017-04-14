using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SADAssignment3.Models;

namespace SADAssignment3.KWIC
{
    public class KWICMasterController
    {
        Input input;
        LineStorage lineStorage;
        CircularShifter circularShifter;
        Alphabetizer alphabetizer;

        public List<KwicOutputModel> KWICOutPut { get; set; }

        public void Execute(List<string> inputList, List<string> noiseWords)
        {
            input = new Input();
            lineStorage = new LineStorage();
            input.Read(inputList, lineStorage);
            
            circularShifter = new CircularShifter(lineStorage);
            circularShifter.Shift();

            alphabetizer = new Alphabetizer(circularShifter);
            alphabetizer.Alphabetize();

            Output output = new Output(alphabetizer, noiseWords);
            

            KWICOutPut = output.Write();            
        }
        
    }
}
