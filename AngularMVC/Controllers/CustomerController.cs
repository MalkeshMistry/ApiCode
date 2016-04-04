using API.Dtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AngularMVC.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult> GetCustomerDetails()
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.GetAsync("/WebApi/customers/");
                if (response.IsSuccessStatusCode)
                {
                    var customers = await response.Content.ReadAsAsync<IList<CustomerDto>>();

                    var jsonResult = new ContentResult
                    {
                        Content = JsonConvert.SerializeObject(customers, settings),
                        ContentType = "application/json"
                    };
                    return jsonResult;
                    //Console.WriteLine("{0}\t${1}\t{2}", product.Name, product.Price, product.Category);
                }
            }

            return Json("error", JsonRequestBehavior.AllowGet);

        }

        [HttpDelete]
        [Route("Customer/DeleteCustomer/{customerId}")]
        public async System.Threading.Tasks.Task DeleteCustomer(string customerId)
        {
            var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.DeleteAsync("/WebApi/customers/" + Convert.ToInt32(customerId));
                if (response.IsSuccessStatusCode)
                {
                }
            }

        }
        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> AddCustomer(CustomerDto customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // New code:
                HttpResponseMessage response = await client.PostAsync("/WebApi/customers/create",new StringContent(JsonConvert.SerializeObject(customer), Encoding.UTF8, "text/json"));
                if (response.IsSuccessStatusCode)
                {

                    return new HttpStatusCodeResult(HttpStatusCode.OK, "Item added");
                }
            }

            return Json("error", JsonRequestBehavior.AllowGet);
        }
    }
}