﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SADAssignment3.Models
{
    public class SearchViewModel
    {        
        public string Keywords { get; set; }
        public List<LineInput> SearchOutPut { get; set; }
        public SearchViewModel()
        {
            SearchOutPut = new List<LineInput>();
            Keywords = "";
        }
    }
}