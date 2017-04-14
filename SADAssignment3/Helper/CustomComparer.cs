using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SADAssignment3.Helper
{
    static public class CustomComparer
    {
        static public int StringComparer(string x, string y)
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