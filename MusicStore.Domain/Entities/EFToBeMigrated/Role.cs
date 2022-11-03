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
    public class Role
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }


    }
}
