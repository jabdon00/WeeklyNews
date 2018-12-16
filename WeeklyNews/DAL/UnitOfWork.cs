using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using WeeklyNews.Models;

namespace WeeklyNews.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ObjectContext _context;
        private CategoryRepository _categoryRepository;
        private NewsRepository _newsRepository;
        public UnitOfWork(ObjectContext context)
        {
            if (context  == null)
            {
                throw new ArgumentNullException();
            }
            _context = context;
        }
        public IRepository<News> NewsRepository
        {
            get
            {
                if (_newsRepository == null)
                {
                    _newsRepository = new NewsRepository(_context);
                }
                return _newsRepository;
            }            
        }
        public IRepository<Category> CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                {
                    _categoryRepository = new CategoryRepository(_context);
                }
                return _categoryRepository;
            }
        }
        public void Commit()
        {
            _context.SaveChanges();            
        }
    }
}