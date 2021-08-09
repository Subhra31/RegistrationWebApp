using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Helpers
{
        public interface IUserAccessor
        {
            User GetUser();
        }
}
