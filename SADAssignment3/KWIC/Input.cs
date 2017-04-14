using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADAssignment3.KWIC
{
    public class Input
    {
        public void Read(List<String> inputList, LineStorage lineStorage)
        {    
                                                   
            for (int i = 0; i < inputList.Count; i++)
            {
                // create new empty line to be filled                        
                lineStorage.AddLine(inputList[i]);                        
            }
            lineStorage.SetCharCore();            
        }
    }
}
