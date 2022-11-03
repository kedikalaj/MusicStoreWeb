using System.Collections.Generic;
using MusicStore.Domain.Entities;
using System.Data.Entity;

namespace MusicStore.Domain.Abstract
{


    public interface ISongsRepository
    {
        IEnumerable<Songs> Songs { get; }
        void SaveProduct(Songs product);
        Songs DeleteProduct(int productID);

    }


}
