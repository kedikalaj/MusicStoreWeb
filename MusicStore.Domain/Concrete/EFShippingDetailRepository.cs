using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    public class EFShippingDetailRepository : IShippingDetailRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<ShippingDetail> ShippingDetail
        {
            get { return context.ShippingDetail; }
        }
        public void SaveShippingDeatails(ShippingDetail detail)
        {

            
                ShippingDetail dbEntry = new ShippingDetail();
                dbEntry.Name = detail.Name;
                dbEntry.Line1 = detail.Line1;
                dbEntry.Line2 = detail.Line2;
                dbEntry.Line3 = detail.Line3;
                dbEntry.City = detail.City;
                dbEntry.State = detail.State;
                dbEntry.Zip = detail.Zip;
                dbEntry.Country=detail.Country;
                dbEntry.GiftWrap = detail.GiftWrap;
                context.ShippingDetail.Add(dbEntry);
            
            context.SaveChanges();
        }
    }
}
