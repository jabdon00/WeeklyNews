using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using WeeklyNews.Models;

namespace WeeklyNews.DAL
{
    public class CategoryRepository : Repository<Category>
    {
        public CategoryRepository(ObjectContext context)
            : base(context)
        {

        }
        public override Category GetById(long id)
        {
            return _objectSet.SingleOrDefault(s => s.Id == id);
        }
    }
}