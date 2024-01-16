using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace Lab3.Models
{
    public class StudentDto
    {
        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Id { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [XmlElement(IsNullable = true)]
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Phone { get; set; }

        public List<Hateoas> SelfLinks { get; set; }
    }
}