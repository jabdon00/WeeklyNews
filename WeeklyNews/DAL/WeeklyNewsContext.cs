using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Linq;
using System.Web;
using WeeklyNews.Interfaces;

namespace WeeklyNews.DAL
{
    public class WeeklyNewsContext :DbContext, IUnitofWork
    {
        public WeeklyNewsContext() : base("WeeklyNewsDB")
        { }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var addMethod = typeof(ConfigurationRegistrar)
              .GetMethods()
              .Single(m =>
                m.Name == "Add"
                && m.GetGenericArguments().Any(a => a.Name == "TEntityType"));

            foreach (var assembly in AppDomain.CurrentDomain
              .GetAssemblies()
              .Where(a => a.GetName().Name != "EntityFramework"))
            {
                var configTypes = assembly
                  .GetTypes()
                  .Where(t => t.BaseType != null
                    && t.BaseType.IsGenericType
                    && t.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

                foreach (var type in configTypes)
                {
                    var entityType = type.BaseType.GetGenericArguments().Single();

                    var entityConfig = assembly.CreateInstance(type.FullName);
                    addMethod.MakeGenericMethod(entityType)
                      .Invoke(modelBuilder.Configurations, new object[] { entityConfig });
                }
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}