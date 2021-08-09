using DAL;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IContactRepository:IRepository<DAL.ContactModel>
    {
        PagingModel<Repositories.Models.ContactModel> GetContact(int page, int pageSize);

        //Contacts GetContactBySp();
    }
}
