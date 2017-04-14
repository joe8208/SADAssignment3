using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SADAssignment3.Models
{
    public class DataInput
    {
        [Required]
        [DataType(DataType.MultilineText)]
        public string DataText { get; set; }
    }
}