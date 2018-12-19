using Microsoft.AspNet.WebFormsDependencyInjection.Unity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using Unity;
using WeeklyNews.Business;
using WeeklyNews.DAL;

namespace WeeklyNews
{
    public class Global : HttpApplication
    {

        
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var unityContainer = this.AddUnity();
            unityContainer.RegisterType(typeof(Repository<>),typeof(WeeklyNewsContext));            
            unityContainer.RegisterType(typeof(UnitOfWork), typeof(Repository<>));
            unityContainer.RegisterType(typeof(CategoryBusiness));

        }

    }
}