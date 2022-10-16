using System.Collections.Generic;
using MusicStore.Domain.Entities;


namespace MusicStoreWeb.Models
{
    public class SongsListViewModel
    {
        public IEnumerable<Song> Songs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}