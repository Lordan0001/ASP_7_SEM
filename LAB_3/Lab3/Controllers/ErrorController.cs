using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace Lab3.Controllers
{
    public class ErrorController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/error.{type}/{id}")]
        public IHttpActionResult Index(int id,string type = "json")
        {
            var enumDesc = ((ErrorNumber)id).ToString();
            return Content(HttpStatusCode.OK, enumDesc, type.Contains("xml")
                ? (MediaTypeFormatter)Configuration.Formatters.XmlFormatter
                : Configuration.Formatters.JsonFormatter);
        }
    }

    public enum ErrorNumber
    {
        ServerError,
        NotFound,
        NotValidParams
    }
}