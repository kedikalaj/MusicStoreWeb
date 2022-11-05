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
    }
}
