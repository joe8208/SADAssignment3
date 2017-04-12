using SADAssignment3.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SADAssignment3.DAL
{
    public class SADAssignment3Initializer : DropCreateDatabaseIfModelChanges<SADAssignment3Context>
    {
        protected override void Seed(SADAssignment3Context context)
        {
            var lineInputs = new List<LineInput>
            {
                new LineInput {Id = 1, Descriptor = "University of Central Oklahoma", Url = "http://www.uco.edu"},
                new LineInput {Id = 2, Descriptor = "University of Oklahoma", Url = "http://www.ou.edu"},
                new LineInput {Id = 3, Descriptor = "Arizona State University", Url = "http://www.asu.edu"},
                new LineInput {Id = 4, Descriptor = "Oklahoma State University", Url = "http://www.osu.edu"}
            };

            lineInputs.ForEach(s => context.LineInputs.Add(s));
            context.SaveChanges();
        }
    }
}