using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StructureMap;

namespace FailTracker.Web.Infrastructure
{
    public class StructureMapDependenctResolver : IDependencyResolver
   {        
        private Func<IContainer> _container;

        public StructureMapDependenctResolver(Func<IContainer> container)
        {
            _container = container;
        }

        public object GetService(Type serviceType) {

            if (serviceType == null) {
                return null;
            }

            var container = _container.Invoke();            
            return serviceType.IsAbstract || serviceType.IsInterface
                   ? container.TryGetInstance(serviceType)
                   : container.GetInstance(serviceType);

        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return _container.Invoke().GetAllInstances(serviceType).Cast<object>();
        }

    }
}