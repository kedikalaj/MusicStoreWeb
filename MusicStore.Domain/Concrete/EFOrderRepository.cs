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
    public class EFOrderRepository : IOrderRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<Order> Order
        {
            get { return context.Order; }
        }


        public void CreateNewOrder(int ShipID,int UID, CartViewModel model)
        {
            

             ShippingDetail sd = context.ShippingDetail.Find(ShipID);

            if (model.Order == null) {
               
                
                    Order dbEntry = new Order();
                    dbEntry.UserID = UID;
                    dbEntry.ShipDetailsID = sd.ID;
                    context.Order.Add(dbEntry);
                }
                else
                {
                int OID = model.Order.ID;
                    Order dbEntry = context.Order.Find(OID);
                    dbEntry.UserID = UID;
                    dbEntry.ShipDetailsID = sd.ID;

                }
                context.SaveChanges();


        }



    }
}
