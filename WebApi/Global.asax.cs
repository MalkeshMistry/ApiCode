using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Api.IOC.Registration.Helper;

using WebApi.App_Start;

namespace WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configuration.Filters.Add(new ErrorHandlingHelper());
            //GlobalConfiguration.Configuration.Filters.Add(new ActionWebApiFilter());
            IocContainer.Initialize(GlobalConfiguration.Configuration);
        }
    }
}
