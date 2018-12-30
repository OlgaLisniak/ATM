using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using ATM.Bootstrap;
using Autofac;
using Autofac.Integration.Mvc;

namespace ATM.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new Autofac.ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            var bootstrapper = new BootstrapperTransient();
            bootstrapper.SetInitializer();
            bootstrapper.RegisterDomainModels(builder);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
