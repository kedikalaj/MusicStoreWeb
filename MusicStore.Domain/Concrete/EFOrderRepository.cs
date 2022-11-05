using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    public class EFOrderRepository : IOrderRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<Order> Order
        {
            get { return context.Order; }
        }
    }
}
