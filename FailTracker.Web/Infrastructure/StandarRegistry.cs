using StructureMap.Configuration.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FailTracker.Web.Infrastructure
{
    public class StandarRegistry : Registry
    {
        public StandarRegistry() {
            Scan(scan =>
            {
                scan.TheCallingAssembly();
                scan.WithDefaultConventions();
            });
        }
    }
}