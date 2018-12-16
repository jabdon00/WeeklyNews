using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using WeeklyNews.Models;

namespace WeeklyNews.DAL
{
    public class NewsRepository : Repository<News>
    {
        public NewsRepository (ObjectContext context)
            : base(context)
        {

        }
        public override News GetById(long id)
        {
            return _objectSet.SingleOrDefault(s => s.Id == id);
        }
    }
}