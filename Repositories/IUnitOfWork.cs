using DAL;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IUnitOfWork
    {
        IContactRepository ContanctRepo { get; }
        IRepository<Country> CountryRepo { get; }
        int SaveChanges();
    }

}
