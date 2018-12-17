using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeeklyNews.Models
{
    public abstract class BaseEntity 
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}