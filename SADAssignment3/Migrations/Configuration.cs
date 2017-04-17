namespace SADAssignment3.Migrations
{
    using SADAssignment3.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SADAssignment3.DAL.SADAssignment3Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SADAssignment3.DAL.SADAssignment3Context context)
        {
            var lineInputs = new List<LineInput>
            {
                new LineInput {Id = 1, Descriptor = "University of Central Oklahoma", Url = "http://www.uco.edu"},
                new LineInput {Id = 2, Descriptor = "University of Oklahoma", Url = "http://www.ou.edu"},
                new LineInput {Id = 3, Descriptor = "Arizona State University", Url = "http://www.asu.edu"},
                new LineInput {Id = 4, Descriptor = "Oklahoma State University", Url = "http://www.osu.edu"}
            };
            lineInputs.ForEach(s => context.LineInputs.AddOrUpdate(s));
            context.SaveChanges();

            var noiseWords = new List<NoiseWord>
            {
                new NoiseWord {Id = 1, Word = "a"},
                new NoiseWord {Id = 2, Word = "an"},
                new NoiseWord {Id = 3, Word = "the"},
                new NoiseWord {Id = 4, Word = "and"},
                new NoiseWord {Id = 5, Word = "or"},
                new NoiseWord {Id = 6, Word = "of"},
                new NoiseWord {Id = 7, Word = "to"},
                new NoiseWord {Id = 8, Word = "be"},
                new NoiseWord {Id = 9, Word = "is"},
                new NoiseWord {Id = 10, Word = "in"},
                new NoiseWord {Id = 11, Word = "out"},
                new NoiseWord {Id = 12, Word = "by"},
                new NoiseWord {Id = 13, Word = "as"},
                new NoiseWord {Id = 14, Word = "at"},
                new NoiseWord {Id = 15, Word = "off"}
            };
            noiseWords.ForEach(s => context.NoiseWords.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
