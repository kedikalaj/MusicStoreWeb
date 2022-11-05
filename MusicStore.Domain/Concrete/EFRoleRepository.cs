using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    public class EFRoleRepository : IRoleRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<Role> Role
        {
            get { return context.Role; }
        }
    }
}
