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
        private UnitOfWork unitOfWork;
        private Repository<Category> categoryRepository;
        public CategoryBusiness(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            categoryRepository = unitOfWork.Repository<Category>();
        }

        public IQueryable<Category> ListView ()
        {
            return categoryRepository.Table;
        }

        public Category GetByID(long Id)
        {
            return categoryRepository.GetById(Id);
        }
        public void AddCategory(string title)
        {
            var category = new Category();
            category.Title = title;
            category.CreatedDate = DateTime.Now;
            category.ModifiedDate = DateTime.Now;
            categoryRepository.Insert(category);
        }
        public void UpdateCategory(long categoryID,string title)
        {
            var category = new Category();
            category = categoryRepository.GetById(categoryID);
            category.Title = title;            
            category.ModifiedDate = DateTime.Now;
            categoryRepository.Update(category);
        }
        public void DeleteCategory(long categoryID)
        {
            var category = new Category();
            category = categoryRepository.GetById(categoryID);
            categoryRepository.Delete(category);            
        }
    }
}