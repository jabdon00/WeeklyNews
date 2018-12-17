using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WeeklyNews.Interfaces;

namespace WeeklyNews.Models
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
    }
}