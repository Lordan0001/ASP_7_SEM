using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LAB_42.Simplex
{
    public class A
    {
        public string s {  get; set; }  
        public int k {  get; set; }
        public float f { get; set; }

        public A() { }
        public A(string s, int k, float f)
        {
            this.s = s;
            this.k = k;
            this.f = f;
        }

    }
}