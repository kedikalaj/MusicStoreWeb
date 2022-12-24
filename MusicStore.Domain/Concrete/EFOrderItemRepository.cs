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
    public class EFOrderItemRepository : IOrderItemRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<OrderItem> OrderItem
        {
            get { return context.OrderItem; }
        }


        public void AddOrder(int OrderID, CartViewModel model)
        {


           Order order = context.Order.Find(OrderID);

            if (model.OrderItem == null)
            {


                OrderItem dbEntry = new OrderItem();

                foreach(var song in model.Cart.Lines)
                {

                    dbEntry.SongID = song.Product.ID;
                    dbEntry.Quantity = song.Quantity;
                    dbEntry.OrderID = order.ID;
                    context.OrderItem.Add(dbEntry);
                    context.SaveChanges();

                }
               

            }
            else
            {
                int OID = model.OrderItem.ID;
                OrderItem dbEntry = context.OrderItem.Find(OID);

                foreach (var song in model.Cart.Lines)
                {

                    dbEntry.SongID = song.Product.ID;
                    dbEntry.Quantity = song.Quantity;
                    dbEntry.OrderID = order.ID;
                    context.OrderItem.Add(dbEntry);
                    context.SaveChanges();

                }


            }
            


        }

    }
}
