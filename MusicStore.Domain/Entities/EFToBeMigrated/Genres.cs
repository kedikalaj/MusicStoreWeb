﻿using System;
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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }

        [ForeignKey("ID")]
        public virtual ICollection<Songs> Songs { get; set; }

        //public virtual Genre Genre { get; set; } 


    }
}
