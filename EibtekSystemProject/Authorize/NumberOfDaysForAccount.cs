using BL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EibtekSystemProject.Authorize
{
    public class NumberOfDaysForAccount : INumberOfDaysForAccount
    {
        private readonly EibtekSystemDbContext _db;
        public NumberOfDaysForAccount(EibtekSystemDbContext db)
        {
            _db = db;
        }

        public int Get(string userId)
        {
            var user = _db.Users.FirstOrDefault(u => u.Id == userId);
            if(user!=null && user.DateCreated != DateTime.MinValue)
            {
                return (DateTime.Today - user.DateCreated).Days;
            }
            return 0;
        }
    }
}
