using System.Collections.Generic;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Abstract
{


    public interface ISongsRepository
    {
        IEnumerable<Song> Songs { get; }

    }


}
