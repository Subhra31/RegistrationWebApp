using DAL;
using Repositories.Implementations;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext _db;
        public UnitOfWork(DatabaseContext db)
        {
            _db = db;
        }
        private IContactRepository _ContanctRepo;
        public IContactRepository ContanctRepo
        {
            get
            {
                if (_ContanctRepo == null)
                    _ContanctRepo = new ContactRepository(_db);
                return _ContanctRepo;
            }
        }

        private IRepository<Country> _CountryRepo;
        public IRepository<Country> CountryRepo
        {
            get
            {
                if (_CountryRepo == null)
                    _CountryRepo = new Repository<Country>(_db);
                return _CountryRepo;
            }
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }

}
