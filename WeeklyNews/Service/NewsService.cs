using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeeklyNews.Interfaces;
using WeeklyNews.Models;

namespace WeeklyNews.Service
{
    public class NewsService: INewsService
    {
        IUnitofWork _uow;
        IDbSet<News> _news;
        public NewsService(IUnitofWork uow)
        {
            _uow = uow;
            _news = _uow.Set<News>();
        }


        public void AddNews(News news)
        {
            _news.Add(news);
        }


        public IList<News> GetAllNews()
        {
            return _news.Include(x => x.Category).ToList();
        }
    }
}