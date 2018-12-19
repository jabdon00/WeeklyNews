using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using WeeklyNews.Business;

namespace WeeklyNews.DAL
{
    public static class UnityConfig
    {
        public static IUnityContainer unityContainer;
        public static void RegisterComponent()
        {
            unityContainer = new UnityContainer();
            unityContainer.RegisterType(typeof(WeeklyNewsContext));
            unityContainer.RegisterType(typeof(Repository<>), typeof(WeeklyNewsContext));
            unityContainer.RegisterType(typeof(UnitOfWork));
            unityContainer.RegisterType(typeof(NewsBusiness));  
            
        }

    }
}