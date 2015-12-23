using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserRepository
    {
        public User GetFirst()
        {
            using (var context = new ForeverAloneDBEntities())
                return context.User.FirstOrDefault();

        }
    }
}
