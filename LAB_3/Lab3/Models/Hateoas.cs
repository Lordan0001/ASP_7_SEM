using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class Hateoas
    {
        public string Href { get; set; }
        public string Rel { get; set; }
        public string Method { get; set; }

        public Hateoas(string href, string rel,string method)
        {
            Href = href;
            Rel = rel;
            Method = method;
        }

        public Hateoas()
        {
            
        }
    }
}