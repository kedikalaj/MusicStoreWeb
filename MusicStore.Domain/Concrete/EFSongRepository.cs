using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using MusicStore.Domain.Models;

namespace MusicStore.Domain.Concrete
{
    public class EFSongRepository : ISongsRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<Songs> Songs
        {
            get { return context.Songs; }
        }
        public void SaveProduct(SongViewModel product)
        {
            if (product.ID == 0)
            {
                Songs dbEntry = new Songs();
                dbEntry.Name = product.Name;
                dbEntry.Author = product.Author;
                dbEntry.Price = product.Price;
                dbEntry.GenreID = product.GenreID;
                dbEntry.Length = product.Length;
                dbEntry.ImageData = product.ImageData;
                dbEntry.ImageMimeType = product.ImageMimeType;
                //product is the name in SongViweMod
                //behet per te gjitha
                context.Songs.Add(dbEntry);
            }
            else
            {
                Songs dbEntry = context.Songs.Find(product.ID);
                if (dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Author = product.Author;
                    dbEntry.Price = product.Price;
                    dbEntry.GenreID = product.GenreID;
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
