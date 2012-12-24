namespace WebApiSample.Windsor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http.Dependencies;

    using Castle.MicroKernel;
    using Castle.MicroKernel.Lifestyle;

    using IDependencyResolver = System.Web.Http.Dependencies.IDependencyResolver;

    public class WindsorDependencyScope : IDependencyScope
    {
        private readonly IKernel container;

        private readonly IDependencyResolver resolver;

        private readonly IDisposable scope;

        public WindsorDependencyScope(IKernel container)
        {
            this.container = container;
            this.scope = container.BeginScope();
        }

        public object GetService(Type serviceType)
        {
            return this.container.HasComponent(serviceType) ? this.container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.ResolveAll(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            this.scope.Dispose();
        }
    }
}