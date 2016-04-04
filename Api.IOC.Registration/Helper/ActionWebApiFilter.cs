using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

using Autofac.Integration.WebApi;

namespace Api.IOC.Registration.Helper
{
    public class ActionWebApiFilter : ActionFilterAttribute, IAutofacActionFilter
    {
        /// <summary>
        /// On action executed event which will fire after each action
        /// </summary>
        /// <param name="actionExecutedContext">The actionExecutedContext</param>
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Response != null)
            {
                actionExecutedContext.Response.StatusCode = actionExecutedContext.Request.Method == HttpMethod.Post ? HttpStatusCode.Created : HttpStatusCode.OK;
            }
        }
    }
}