using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SADAssignment3.KWIC
{
    public class KWICMasterController
    {
        Input input;
        LineStorage lineStorage;
        CircularShifter circularShifter;
        Alphabetizer alphabetizer;

        public List<string> KWICOutPut { get; set; }

        public void Execute(List<string> inputList, List<string> noiseWords)
        {
            input = new Input();
            lineStorage = new LineStorage();
            input.Read(inputList, lineStorage);

            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            circularShifter = new CircularShifter(lineStorage);
            circularShifter.Shift();

            alphabetizer = new Alphabetizer(circularShifter);
            alphabetizer.Alphabetize();

            Output output = new Output(alphabetizer, noiseWords);
            

            KWICOutPut = output.Write();
            //sw.Stop();
            //Console.WriteLine(sw.Elapsed.ToString());
            //Console.ReadLine();
        }
        
    }
}
