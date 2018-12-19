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
        public NewsBusiness(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            newsRepositorty = unitOfWork.Repository<News>();
        }

        public IQueryable<News> FetchAll()
        {
            return newsRepositorty.Table;
        }

        public News GetByID(long Id)
        {
            return newsRepositorty.GetById(Id);
        }
        public void AddNews(string title, DateTime date, string desc, byte[] image, Category category)
        {
            var news = new News();
            news.Title = title;
            news.Date = date;
            news.Description = desc;
            news.Category = category;
            news.Image = image;
            news.CreatedDate = DateTime.Now;
            news.ModifiedDate = DateTime.Now;
            newsRepositorty.Insert(news);
        }
        public void UpdateNews(long newsID, string title)
        {
            var news = new News();
            news = newsRepositorty.GetById(newsID);
            news.Title = title;
            news.ModifiedDate = DateTime.Now;
            newsRepositorty.Update(news);
        }
        public void DeleteNews(long newsID)
        {
            var news = new News();
            news = newsRepositorty.GetById(newsID);
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