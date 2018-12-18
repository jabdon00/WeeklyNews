using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WeeklyNews.Models;

namespace WeeklyNews.Mapping
{
    public class NewsMap : EntityTypeConfiguration<News>
    {
        public NewsMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Title).IsRequired();
            Property(t => t.Description).IsRequired();
            Property(t => t.Image).IsRequired();            
        }
    }
}