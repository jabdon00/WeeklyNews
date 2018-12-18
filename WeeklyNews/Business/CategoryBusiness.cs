using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyNews.DAL;
using WeeklyNews.Models;

namespace WeeklyNews.Business
{
    public class CategoryBusiness
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new WeeklyNewsContext());
        private Repository<Category> categoryRepository;
        public CategoryBusiness()
        {
            categoryRepository = unitOfWork.Repository<Category>();
        }

        public IQueryable<Category> ListView ()
        {
            return categoryRepository.Table;
        }
        public void AddCategory(string title)
        {
            var category = new Category();
            category.Title = title;
            category.CreatedDate = DateTime.Now;
            category.ModifiedDate = DateTime.Now;
            categoryRepository.Insert(category);
        }
    }
}