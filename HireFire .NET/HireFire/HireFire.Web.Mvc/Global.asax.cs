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
            container.RegisterType<IMessengerService, MessengerService>();
            container.RegisterType<IUserAuthenticationService, UserAuthenticationService>();
            container.RegisterType<DbContext, HireFireDbContext>();
            container.RegisterType<ITransactionService, TransactionService>();
            container.RegisterType<IGigService, GigService>();
            container.RegisterType<IBuyerGraphService, BuyerGraphService>();
            container.RegisterType<ISellerGraphService, SellerGraphService>();
            container.RegisterType<ISkillService, SkillService>();
            container.RegisterType<IBuyerTableService, BuyerTableService>();

            container.RegisterType<ILanguageService, LanguageService>();

            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<ITaskService, TaskService>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            //IUnityContainer container = new UnityContainer();
            //container.RegisterType<IAdminService, AdminService>();
            //container.RegisterType<DbContext, HireFireDbContext>();

            //DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
