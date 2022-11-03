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
        public IEnumerable<Songs> Songs
        {
            get { return context.Songs; }
        }
        public void SaveProduct(Songs product)
        {
            if (product.ID == 0)
            {
                context.Songs.Add(product);
            }
            else
            {
                Songs dbEntry = context.Songs.Find(product.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Author = product.Author;
                    dbEntry.Price = product.Price;
                    dbEntry.Genre = product.Genre;
                    dbEntry.Length = product.Length;
                    dbEntry.ImageData = product.ImageData;
                    dbEntry.ImageMimeType = product.ImageMimeType;
                }

            }
            context.SaveChanges();
        }
        public Songs DeleteProduct(int productID)
        {
            Songs dbEntry = context.Songs.Find(productID);
            if (dbEntry != null)
            {
                context.Songs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
