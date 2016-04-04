using Api.IOC.Registration;
using Autofac;
using Autofac.Configuration;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace WebApi.App_Start
{
    public static class IocContainer
    {
        public static void Initialize(HttpConfiguration config)
        {
            var container = RegisterServices(new ContainerBuilder());


            var resolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            // register all modules here - begin
            builder.RegisterAssemblyModules(typeof(MyAPIModule).Assembly);
            //// register all modules here - end

            //builder.RegisterModule(new XmlFileReader("autofac.config"));

            builder.RegisterApiControllers(
                new[]
                {
                    Assembly.GetExecutingAssembly()
                });

            return builder.Build();
        }
    }
}