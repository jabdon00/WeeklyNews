using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WeeklyNews.Models
{
    public class VwNews : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }        
        public long CategoryID {get;set;}
        public string CategoryTitle { get; set; }
    }
}