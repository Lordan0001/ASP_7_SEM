using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace LAB_42.Simplex
{
    /// <summary>
    /// Summary description for Simplex
    /// </summary>
    [WebService(Namespace = "http://BVD/", Description = "Very nice Simplex service")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
  //  [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class Simplex : System.Web.Services.WebService
    {

        [WebMethod(Description ="returns Hello world string",MessageName ="Hello")]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod(Description = "returns int x + int y", MessageName = "Add")]
        public int Add(int x, int y)
        {
            return x + y;
        }
        [WebMethod(Description = "returns string s + double d", MessageName = "Concat")]
        public string Concat(string s, double d)
        {
            return s + d;
        }
        [WebMethod(Description = "returns new A-object (a1 + a2)", MessageName = "Sum")]
        public A Sum(A a1, A a2)
        {
            this.Context.Request.SaveAs(@"D:\University\Current\ASP\All\req.txt", true);
            A a = new A();
            a.f = a1.f + a2.f;
            a.k = a1.k + a2.k;
            a.s = a1.s + a2.s;
            return a;
        }

        [WebMethod(MessageName = "Adds", Description = "int x, int y return x + y request - Ajax, response - json")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public int Adds(int x, int y)
        {
            return x + y;
        }

    }
}
