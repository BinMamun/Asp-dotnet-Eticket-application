﻿using ETicket_Application.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ETicket_Application.Models
{
    public class Movie: IEntityBase
    {
        public int Id { get; set; }
        [Required, StringLength(50), Display(Name = "Movie Name")]
        public string Name { get; set; }
        [StringLength(200)]
        public string Description { get; set; }
        [Required, Display(Name = "Start Date"), Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Required, Display(Name = "End Date"), Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        [Required,Column(TypeName ="money"), DisplayFormat(DataFormatString ="{0:0.00}")]
        public double Price { get; set; }
        public string Image { get; set; }

        //Relationships
        //Actor_Movie
        public List<Actor_Movie> Actors_Movies { get; set; }
        //Producer
        [Required, ForeignKey(" Producer")]
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        
        //Cinema
        [Required, ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }

        //MovieCategory
        [Required, ForeignKey("MovieCategory")]
        public int MovieCategoryId { get; set; }
        public MovieCategory MovieCategory { get; set; }
    }
}
