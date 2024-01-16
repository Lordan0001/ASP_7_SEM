using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using Microsoft.Ajax.Utilities;

namespace Lab3.Models
{
    public class StudentResponseDto
    {
        public List<StudentDto> Students { get; set; }

        public List<Hateoas> GlobalLinks { get; set; }
    }
}