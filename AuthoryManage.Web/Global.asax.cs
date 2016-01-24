using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac.Integration.Mvc;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace AuthoryManage.Web {
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            var assembly = Assembly.GetExecutingAssembly();
            var repository = System.Reflection.Assembly.Load("AuthoryManage.Repository");
            builder.RegisterAssemblyTypes(repository, repository).Where(m => m.Namespace.StartsWith("AuthoryManage.Repository.MsSql"))
              .AsImplementedInterfaces();
            var service = System.Reflection.Assembly.Load("AuthoryManage.Service");
            builder.RegisterAssemblyTypes(service, service)
              .AsImplementedInterfaces();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            builder.RegisterType<AuthoryManage.Repository.DbManage.DbFactory>().As<AuthoryManage.InterfaceRepository.IDbFactory>();
            //容器
            var container = builder.Build();
            //注入改为Autofac注入
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}