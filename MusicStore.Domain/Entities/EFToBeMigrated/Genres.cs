using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Entities
{
    public class Genres
    {

        [Key]
        public int GenreID { get; set; }
        public String GenreName { get; set; }

        [ForeignKey("GenreID")]
        public virtual Song Song { get; set; }



        //public virtual Genre Genre { get; set; } 


    }
}
