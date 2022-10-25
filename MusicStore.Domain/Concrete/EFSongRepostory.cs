using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;


namespace MusicStore.Domain.Concrete
{
    public class EFSongRepository : ISongsRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<Song> Songs
        {
            get { return context.Songs; }
        }
        public void SaveProduct(Song product)
        {
            if (product.SongID == 0)
            {
                context.Songs.Add(product);
            }
            else
            {
                Song dbEntry = context.Songs.Find(product.SongID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Author = product.Author;
                    dbEntry.Price = product.Price;
                    dbEntry.Genre = product.Genre;
                    dbEntry.Length = product.Length;
                }
            }
            context.SaveChanges();
        }
                
    }
}
