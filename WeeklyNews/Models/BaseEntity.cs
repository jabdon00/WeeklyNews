using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeeklyNews.Interfaces;

namespace WeeklyNews.Models
{
    public abstract class BaseEntity : IEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}