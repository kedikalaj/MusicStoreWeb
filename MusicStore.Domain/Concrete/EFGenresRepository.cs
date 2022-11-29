using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    public class EFGenresRepository : IGenresRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<Genres> Genres
        {
            get { return context.Genres; }
        }

        public void SaveGenre(Genres genres)
        {

            if (genres.ID == 0)
            {
                context.Genres.Add(genres);
            }

            else
            {
                Genres dbEntry = context.Genres.Find(genres.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = genres.Name;

                }

            }
            context.SaveChanges();

        }
        public Genres DeleteGenre(int ID)
        {
            Genres dbEntry = context.Genres.Find(ID);
            if (dbEntry != null)
            {
                context.Genres.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Genres GetGenreById(int id)
        {
            return Genres.Single(g => g.ID == id);
        }
       public List<Genres> GetGenres()
        {


            List<Genres> genres = new List<Genres>();
            foreach (var p in Genres)
            {
                new Genres() { ID = p.ID, Name = p.Name };
            }

            return genres;
          
        }
    }
}
