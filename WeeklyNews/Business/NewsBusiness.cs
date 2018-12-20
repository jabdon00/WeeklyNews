using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using WeeklyNews.DAL;
using WeeklyNews.Models;

namespace WeeklyNews.Business
{
    public class NewsBusiness
    {
        private UnitOfWork unitOfWork;
        private Repository<News> newsRepositorty;
        private Repository<Category> categoryRepository;
        public NewsBusiness(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            newsRepositorty = unitOfWork.Repository<News>();
            categoryRepository = unitOfWork.Repository<Category>();
        }

        public IQueryable<News> FetchAll()
        {
            return newsRepositorty.Table;
        }
        public IQueryable<VwNews> FetchJoined()
        {
            var categories = categoryRepository.Table;
            var news = newsRepositorty.Table;
            return (from p in news
                    join c in categories
                    on p.CategoryID equals c.Id
                    orderby p.Date
                    select new VwNews
                    {
                        Id = p.Id,
                        Title = p.Title,
                        Date = p.Date,
                        Description = p.Description,
                        CategoryTitle = c.Title,
                        Image = p.Image
                    }
                );
        }
        public List<VwNews> FetchTopFive()
        {            
            var dbc = new WeeklyNewsContext();
            return dbc.Database.SqlQuery<VwNews>(@"select a.Id,a.Date,b.Title CategoryTitle,a.Title ,a.Description,a.Image from
                                           (select *, ROW_NUMBER() over(partition by CategoryID order by Date) rankno from News) a
                                            join Categories b on a.CategoryID = b.Id
                                            where rankno <= 5").ToList();            
        }
        public News GetByID(long Id)
        {
            return newsRepositorty.GetById(Id);
        }
        public void AddNews(string title, DateTime date, string desc, byte[] image, long categoryID)
        {
            var news = new News();
            news.Title = title;
            news.Date = date;
            news.Description = desc;
            news.CategoryID = categoryID;
            news.Image = image;
            news.CreatedDate = DateTime.Now;
            news.ModifiedDate = DateTime.Now;
            newsRepositorty.Insert(news);
        }
        public void UpdateNews(long newsID, string title, DateTime date, string desc, byte[] image, long categoryID)
        {
            var news = newsRepositorty.GetById(newsID);
            news.Title = title;
            news.Date = date;
            news.Description = desc;
            news.CategoryID = categoryID;
            news.Image = image;
            news.ModifiedDate = DateTime.Now;
            newsRepositorty.Update(news);
        }
        public void DeleteNews(long newsID)
        {
            var news = newsRepositorty.GetById(newsID);
            newsRepositorty.Delete(news);
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}