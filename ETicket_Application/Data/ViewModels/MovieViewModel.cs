using ETicket_Application.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace ETicket_Application.Data.ViewModels
{
    public class MovieViewModel
    {        
        [Required, StringLength(50), Display(Name = "Movie Name")]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required, Display(Name = "Start Date"), Column(TypeName="Date")]
        public DateTime StartDate { get; set; }
        [Required, Display(Name = "End Date"), Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        [Required, Column(TypeName = "money"), Display(Name ="Price in (Tk)"), DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Price { get; set; }
        public string Image { get; set; }
        //Relationships
        //Actor_Movie
        [Required, Display(Name = "Actor(s)")]
        public List<int> ActorIds { get; set; }
        //Producer
        [Required, Display(Name="Producer")]
        public int ProducerId { get; set; }    
        //Cinema
        [Required, Display(Name = "Cinema")]
        public int CinemaId { get; set; }     
        //MovieCategory
        [Required, Display(Name = "Genre")]
        public int MovieCategoryId { get; set; }
    }
}
