using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Entities;
using System.Data.Entity;

namespace MusicStore.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Genres> Genres { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<ShippingDetail> ShippingDetails { get; set; }
        public DbSet<Songs> Songs { get; set; }
        public DbSet<User> Users { get; set; }


    }

}
