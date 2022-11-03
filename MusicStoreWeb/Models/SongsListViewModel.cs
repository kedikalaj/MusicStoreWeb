using System.Collections.Generic;
using MusicStore.Domain.Entities;


namespace MusicStoreWeb.Models
{
    public class SongsListViewModel
    {
        public IEnumerable<Songs> Songs { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
    }
}