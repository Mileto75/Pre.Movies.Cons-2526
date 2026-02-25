using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pre.Movies.Core.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public List<string> Genre { get; set; }
        public double Rating { get; set; }
        public string Director { get; set; }
        public List<string> Actors { get; set; }
        public string Awards { get; set; }
        public string Country { get; set; }
        public string BoxOffice { get; set; }
    }


}
