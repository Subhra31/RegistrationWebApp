using DAL;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Repositories.Implementations
{
    public class ContactRepository: Repository<DAL.ContactModel>, IContactRepository
    {
        public DatabaseContext context
        {
            get
            {
                return _dbContext as DatabaseContext;
            }
        }
        public ContactRepository(DbContext _db) : base(_db)
        {

        }
        public PagingModel<Repositories.Models.ContactModel> GetContact(int page, int pageSize)
        {
            var data = (from prd in context.Contacts
                        join cat in context.Country
                        on prd.ContactId equals cat.CountryId
                        orderby prd.ContactId
                        select new Repositories.Models.ContactModel
                        {
                            ContactId = prd.ContactId,
                            Name = prd.Name,
                            MobileNo = prd.MobileNo,
                            Image = prd.Image,
                            Designation = prd.Designation,
                            CountryId = cat.CountryId,
                            Gender = prd.Gender
                        });

            int count = data.Count();
            var dataList = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PagingModel<Repositories.Models.ContactModel> model = new PagingModel<Repositories.Models.ContactModel>();
            if (dataList.Count > 0)
            {
                model.Data = new StaticPagedList<Repositories.Models.ContactModel>(dataList, page, pageSize, count);
                model.Page = page;
                model.PageSize = pageSize;
                model.TotalPages = count;
            }
            return model;
        }
    }
}
