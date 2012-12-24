namespace WebApiSample
{
    using System.Web;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Castle.Windsor;
    using Castle.Windsor.Installer;

    using WebApiSample.App_Start;
    using WebApiSample.Windsor;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiSampleApplication : HttpApplication
    {
        private readonly WindsorContainer container;

        public WebApiSampleApplication()
        {
            this.container = new WindsorContainer();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            this.RegisterDependencyResolver();
            this.InstallDependencies();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        private void InstallDependencies()
        {
            this.container.Install(FromAssembly.This());
        }

        private void RegisterDependencyResolver()
        {
            GlobalConfiguration.Configuration.DependencyResolver = new WindsorDependencyResolver(this.container.Kernel);
        }
    }
}