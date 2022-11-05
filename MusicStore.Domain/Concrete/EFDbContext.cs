using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;
using System.Data.Entity;

namespace MusicStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Order> Order { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Role> Role { get; set; }

        public DbSet<ShippingDetail> ShippingDetail { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<User> User { get; set; }


    }

}
