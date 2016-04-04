using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using API.Dtos;
using API.Interface;

using Api.IOC.Registration.Helper;

using Autofac;
using Autofac.Features.Indexed;
using Autofac.Integration.WebApi;

using Domain.Model;

using Mappers;

using Repository;
using Repository.Domain;
using Repository.Entities;
using Repository.Interface;
using Repository.Mappers;

namespace Api.IOC.Registration
{
    public class MyAPIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // domain
            builder.RegisterType<Domain.Domain>().As<IDomain>();

            builder.RegisterType<Repository.Repository>().As<IRepository>();
            builder.RegisterType<RepositoryProvider>().As<IRepositoryProvider>();
            builder.RegisterType<RepositoryManager>().As<IRepositoryManager>();
            builder.RegisterType<CustomerEntityModelMapper>().As<IMapper<CustomerEntity, CustomerModel>>();

            builder.Register(c => new RepositoryContext()).As<IRepositoryContext>();
            builder.RegisterType<Repository.Repository>().As<IRepository>().Keyed<IQueryableRepository>(typeof(IRepository));
            builder.Register<Func<IRepositoryContext, IQueryableRepository>>(ctx => ctx.ResolveKeyed<IQueryableRepository>);
            builder.Register(c => new RepositoryProvider(
                                      c.Resolve<Func<IRepositoryContext>>(),
                                      c.Resolve<IMapper<CustomerEntity, CustomerModel>>(),
                                      c.Resolve<IIndex<Type, Func<IRepositoryContext, IQueryableRepository>>>())).As<IRepositoryProvider>();
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);
            builder.Register(c => new ActionWebApiFilter()).AsWebApiActionFilterFor<ApiController>().InstancePerRequest();
            //builder.RegisterType<ErrorHandlingHelper>()
            //    .As<IAutofacExceptionFilter>()
            //    .WithParameter("helper", null);
           // var container = ConfigureContainer("DictionaryParameters").Build();
            //builder.Register((c, p) =>
            //       new ErrorHandlingHelper(p.TypedAs<IDictionary<Type, HttpStatusCode>>())).AsWebApiExceptionFilterFor<ApiController>().InstancePerRequest();
        // .As<IAutofacExceptionFilter>();
            //builder.Register((c, p) => new ErrorHandlingHelper(c.Resolve<IDictionary<Type, HttpStatusCode>>(p))).AsWebApiExceptionFilterFor<ApiController>().InstancePerRequest();
           // builder.Register(c => new ErrorHandlingHelper(c.Resolve<IDictionary<Type, HttpStatusCode>>())).AsWebApiExceptionFilterFor<ApiController>().InstancePerRequest();
            // service
            builder.RegisterType<CustomerDtoModelMapper>().As<IMapper<CustomerDto, CustomerModel>>();
        }
    }
}
