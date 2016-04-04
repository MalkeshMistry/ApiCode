using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

using Autofac.Integration.WebApi;

namespace Api.IOC.Registration.Helper
{
  
    public class ErrorHandlingHelper : ExceptionFilterAttribute, IAutofacExceptionFilter
    {
        private IDictionary<Type, HttpStatusCode> _exceptionStatusCodeMapping;

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandlingHelper" /> class.
        /// </summary>
        /// <param name="exceptionStatusCodeMapping">The dictionary of Http status code and exception type</param>
        public ErrorHandlingHelper(IDictionary<Type, HttpStatusCode> exceptionStatusCodeMapping) : this()
        {
            if (exceptionStatusCodeMapping != null && exceptionStatusCodeMapping.Count > 0)
            {
                this._exceptionStatusCodeMapping =
                    this._exceptionStatusCodeMapping.Concat(
                        exceptionStatusCodeMapping.Except(this._exceptionStatusCodeMapping.Intersect(exceptionStatusCodeMapping)))
                        .ToDictionary(x => x.Key, x => x.Value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorHandlingHelper" /> class.
        /// </summary>
        public ErrorHandlingHelper()
        {
            this._exceptionStatusCodeMapping = new Dictionary<Type, HttpStatusCode>();
            this._exceptionStatusCodeMapping.Add(typeof(NotImplementedException), HttpStatusCode.NotImplemented);
            this._exceptionStatusCodeMapping.Add(typeof(UnauthorizedAccessException), HttpStatusCode.Unauthorized);
            this._exceptionStatusCodeMapping.Add(typeof(ArgumentNullException), HttpStatusCode.BadRequest);
        }

        /// <summary>
        /// On exception occurs event
        /// </summary>
        /// <param name="context">The HttpActionExecutedContext</param>
        public override void OnException(HttpActionExecutedContext context)
        {
            var message = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content =
                    new StringContent(
                    string.Join(
                        Environment.NewLine,
                        context.Exception.Message,
                        context.Exception.InnerException,
                        context.Exception.StackTrace))
            };

            // ToDo: Later on need to implement required exceptions
            if (context.Exception is NotImplementedException)
            {
                message.StatusCode = HttpStatusCode.NotImplemented;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                message.StatusCode = HttpStatusCode.Unauthorized;
            }
            else if (context.Exception is ValidationException)
            {
                message.StatusCode = HttpStatusCode.BadRequest;
            }
            else
            {
                message.StatusCode = HttpStatusCode.InternalServerError;
            }

            context.Response = message;
        }
    }
}