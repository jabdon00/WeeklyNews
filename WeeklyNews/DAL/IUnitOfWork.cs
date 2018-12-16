using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyNews.Models;

namespace WeeklyNews.DAL
{
    public interface IUnitOfWork
    {
        IRepository<News> NewsRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        void Commit();
    }
}
