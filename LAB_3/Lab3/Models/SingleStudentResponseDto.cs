﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Models
{
    public class SingleStudentResponseDto
    {
        public StudentDto Student { get; set; }

        public List<Hateoas> GlobalLinks { get; set; }
    }
}