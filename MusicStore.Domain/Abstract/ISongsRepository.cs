using System.Collections.Generic;
using MusicStore.Domain.Entities;
using System.Data.Entity;
using MusicStore.Domain.Models;

namespace MusicStore.Domain.Abstract
{


    public interface ISongsRepository
    {
        IEnumerable<Songs> Songs { get; }
        void SaveProduct(SongViewModel product);
        Songs DeleteProduct(int productID);

    }


}
