using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebForm
{
    public class Server : ISimplexSoap
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public string Concat(string s, double d)
        {
            return s + d;
        }

        [return: XmlElement("HelloResult")]
        public string HelloWorld()
        {
            return "Hello World";
        }

        public A Sum(A a1, A a2)
        {
            A a3 = new A();
            a3.s = a1.s + a2.s;
            a3.f = a1.f + a2.f;
            a3.k = a1.k + a2.k;

            return a3;
        }
    }
}