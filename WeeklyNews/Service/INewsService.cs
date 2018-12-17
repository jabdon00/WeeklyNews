using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeklyNews.Models;

namespace WeeklyNews.Service
{
    public interface INewsService
    {
        void AddNews(News news);
        IList<News> GetAllNews();
    }
}
