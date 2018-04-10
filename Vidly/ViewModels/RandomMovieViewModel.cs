//ViewModel -- we use a ViewModel only in rendering views
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class RandomMovieViewModel
    {
        public List<Movie> MovieList { get; set; }
    }
}