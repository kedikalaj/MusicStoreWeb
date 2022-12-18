using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore.Domain.Abstract;
using MusicStore.Domain.Entities;

namespace MusicStore.Domain.Concrete
{
    public class EFUserRepository : IUserRepository
    {
        public EFDbContext context = new EFDbContext();
        public IEnumerable<User> User
        {
            get { return context.User; }
        }

        public List<string> GetUser()
        {
            List<string> Names = context
                     .User
                    .Where(u => u.ID > 0)
                    .Select(u => u.Username)
                    .ToList();
            return Names;
        }
       


            public void SaveUser(User user) {

            if (user.ID == 0)
            {
                user.RoleID = 2;
                context.User.Add(user);
            }

            else
            {
             
                User dbEntry = context.User.Find(user.ID);
                if (dbEntry != null)
                {
                    dbEntry.Username = user.Username;
                    dbEntry.Password = user.Password;
                    dbEntry.RoleID = 2;

                }

            }
            context.SaveChanges();

        }
    }
}
