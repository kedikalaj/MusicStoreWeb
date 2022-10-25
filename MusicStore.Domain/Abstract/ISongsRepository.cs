using System.Collections.Generic;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Abstract
{


    public interface ISongsRepository
    {
        IEnumerable<Song> Songs { get; }
        void SaveProduct(Song product);
        Song DeleteProduct(int productID);

    }


}
