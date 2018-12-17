using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WeeklyNews.Interfaces;

namespace WeeklyNews.Models
{
    public class News : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }       
        public Category Category { get; set; }
  
    }
}