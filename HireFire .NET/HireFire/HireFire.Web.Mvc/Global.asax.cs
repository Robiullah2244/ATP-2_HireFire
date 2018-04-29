using Hirefire.Core.Services.Interfaces;
using HireFire.Core.Services;
using HireFire.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace HireFire.Web.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IUnityContainer container = new UnityContainer();
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<IBuyerService, BuyerService>();
            container.RegisterType<ISellerService, SellerService>();
            container.RegisterType<DbContext, HireFireDbContext>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IAdminService, AdminService>();
            //container.RegisterType<DbContext, HireFireDbContext>();

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
