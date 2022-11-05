using System.Collections.Generic;
using MusicStore.Domain.Entities;


namespace MusicStoreWeb.Models
{
    public class GenresListViewmodel
    {
        public IEnumerable<Songs> Songs { get; set; }
   
        public IEnumerable<Genres> Genres { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public int? CurrentCategory { get; set; }

 
    }
}