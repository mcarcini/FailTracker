using FailTracker.Web.Infrastructure;
using StructureMap;
using StructureMap.TypeRules;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FailTracker.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public IContainer Container
        {
            get
            {
                return (IContainer) HttpContext.Current.Items["_Container"];
            }
            set
            {
                HttpContext.Current.Items["_Container"] = value;
            }
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            DependencyResolver.SetResolver(
                new StructureMapDependenctResolver(() => Container ?? ObjectFactory.Container));

            ObjectFactory.Configure(cfg =>
            {
                cfg.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.With(new ControllerConvention());
                });

                cfg.For<IFilterProvider>().Use(
                    new StructureMapFilterProvider(() => Container ?? ObjectFactory.Container));

                cfg.SetAllProperties(x =>
                    x.Matching(p =>
                       p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) &&
                       p.DeclaringType.Namespace.StartsWith("FailTracker") &&
                       !p.PropertyType.IsPrimitive &&
                       p.PropertyType != typeof(string)
                        )
                    );
            });
        }

        public void Application_BeginRequest() 
        {
            Container = ObjectFactory.Container.GetNestedContainer();
        }

        public void Application_EndRequest() 
        {
            Container.Dispose();
            Container = null;
        }
    }
}
