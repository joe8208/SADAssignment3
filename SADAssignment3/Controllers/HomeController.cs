using SADAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SADAssignment3.KWIC;
using SADAssignment3.DAL;

namespace SADAssignment3.Controllers
{
    public class HomeController : Controller
    {
        //private SADAssignment3Context db = new SADAssignment3Context();
        private UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Search()
        {
            SearchViewModel model = new SearchViewModel();
            return View(model);
        }


        // input data into kwic
        // run kwic return list of results
        // search from list of results and find keywords within the list.
        // return the original unshifted descriptor value and url for found keyword.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchViewModel model)
        {

            // 1. read from db and input data into KWIC

            List<LineInput> listOfLineInputs = unitOfWork.LineInputRepository.Get().ToList();
            List<string> input = listOfLineInputs.Select(s => s.Descriptor).ToList();

            List<string> noiseWords = unitOfWork.NoiseWordRepository.Get().Select(s => s.Word).ToList();

            KWICMasterController mc = new KWICMasterController();
            mc.Execute(input, noiseWords);
            var shiftedOutput = mc.KWICOutPut;
            int[] linesWithKeywordsFound = new int[mc.LineIndexLength];


            // read input and parse into individual words to search by.
            string[] keywords = model.Keywords.Trim().Split(new char[] { ' ' });

            // search through the shifted lines and find the ones with the keywords

            for (int i = 0; i < keywords.Length; i++)
            {
                // linear search through array to find matches
                for (int j = 0; j < shiftedOutput.Count; j++)
                {
                    if (CustomComparable(keywords[i], shiftedOutput[j].ShiftedLine.Split(new char[] { ' ' })[0]) == 0)
                    {
                        linesWithKeywordsFound[shiftedOutput[j].LineIndex] += 1;
                    }
                }

            }

            // loop through the list of lines with found keywords and construct list of decriptors
            // and urls to return to the view.

            for(int i = 0; i < linesWithKeywordsFound.Length; i++)
            {
                // compare to see if the count # matches that of the number of keywords being searched.
                if (linesWithKeywordsFound[i] == keywords.Length)
                {
                    // grab LineInput from db that matches the index of the found result

                    model.SearchOutPut.Add(listOfLineInputs[i]);
                }
            }

            //var x = model.SearchOutPut;

            return View(model);
        }        

        int[] binarySearch(string[] keywords, List<KwicOutputModel> shiftedOutput)
        {
            // create an int array to store the found keyword line indexs.
            // needs to be changed to create the array based on the lineindex length
            int[] linesWithKeywordsFound = new int[shiftedOutput.Count];

            for(int i = 0; i < keywords.Length; i++)
            {
                int low = 0;
                int mid = 0;
                int high = shiftedOutput.Count - 1;

                while (low <= high)
                {
                    mid = (low + high) / 2;
                    // get first word in line from the middle of the arraylist
                    string midWord = shiftedOutput[mid].ShiftedLine.Split(new char[] { ' ' })[0];

                    int compared = CustomComparable(keywords[i], midWord);

                    if (compared > 0)
                        low = mid + 1;
                    else if (compared < 0)
                        high = mid - 1;
                    else
                    {
                        // they are the same, keyword found
                        // do a linear search from low to high to 
                        // find ALL instances of the search word
                        // because binary seach only returns one.



                        for (int j = low; j <= high; j++)
                        {
                            if (CustomComparable(keywords[i], shiftedOutput[j].ShiftedLine.Split(new char[] { ' ' })[0]) == 0)
                            {
                                // needs line index not mid for logging 
                                linesWithKeywordsFound[mid] += 1;
                            }
                        }

                        low = mid;
                        high = mid - 1;
                    }
                }
            }
            
            return linesWithKeywordsFound;
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
                            else if (x.Length > y.Length)
                                return 1;
                            else
                                return 0;
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