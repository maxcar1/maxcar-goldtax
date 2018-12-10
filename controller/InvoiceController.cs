using maxcar_goldtax.entity;
using maxcar_goldtax.utils;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace maxcar_goldtax.controller
{
    public class InvoiceController : ApiController
    {
        public Response Get()
        {
            Response response = new Response();
            short code = Module.InitCard();
            JObject jObject = new JObject
            {
                ["RetCode"] = code
            };
            response.Data = jObject;
            return response;
        }
    }
}
