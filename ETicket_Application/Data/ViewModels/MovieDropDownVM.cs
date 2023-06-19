using ETicket_Application.Models;
using System.Collections.Generic;

namespace ETicket_Application.Data.ViewModels
{
    public class MovieDropDownVM
    {
        public MovieDropDownVM()
        {
            Cinemas = new List<Cinema>();
            MovieCategories = new List<MovieCategory>();
            Producers = new List<Producer>();
            Actors = new List<Actor>();
        }
        public List<Cinema> Cinemas { get; set; }
        public List<MovieCategory> MovieCategories { get; set; }
        public List<Producer> Producers { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
