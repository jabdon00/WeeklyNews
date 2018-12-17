﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyNews.DAL;
using WeeklyNews.Models;

namespace WeeklyNews.Business
{
    public class CategoryBusiness
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<Category> categoryRepository;
        public CategoryBusiness()
        {
            categoryRepository = unitOfWork.Repository<Category>();
        }

        public IEnumerable<Category> ListView ()
        {
            return categoryRepository.Table.ToList();
        }
    }
}