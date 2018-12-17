using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WeeklyNews.Interfaces;
using WeeklyNews.Models;

namespace WeeklyNews.Service
{
    public class CategoryService : ICategoryService
    {
        IUnitofWork _uow;
        IDbSet<Category> _categories;
        public CategoryService(IUnitofWork uow)
        {
            _uow = uow;
            _categories = _uow.Set<Category>();
        }


        public void AddNewCategory(Category category)
        {
            _categories.Add(category);
        }


        public IList<Category> GetAllCategories()
        {
            return _categories.ToList();
        }

    }
}