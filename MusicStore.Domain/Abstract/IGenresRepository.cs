using System.Collections.Generic;
using MusicStore.Domain.Entities;
using System.Data.Entity;

namespace MusicStore.Domain.Abstract
{
    public interface IGenresRepository
    {
        IEnumerable<Genres> Genres { get; }
        void SaveGenre(Genres product);

        Genres DeleteGenre(int ID);

        Genres GetGenreById(int id);


    }
}
