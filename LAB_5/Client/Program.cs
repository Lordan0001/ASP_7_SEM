using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string binding = "BasicHttpBinding_IWCFSimplex";
            WCFReference.WCFSimplexClient simpleClient = new WCFReference.WCFSimplexClient(binding);
            Console.WriteLine("ADD: " + simpleClient.Add(12, 56));
            Console.WriteLine("CONCAT: " + simpleClient.Concat("somestr", 666));
            WCFReference.A a = simpleClient.Sum(new WCFReference.A { f = 6.2f, k = 33, s = "some " }, new WCFReference.A { f = 1.3f, k = 2, s = "str" });
            Console.WriteLine($"SUM: f = {a.f} k = {a.k} s = {a.s}");
            Console.ReadLine();
            simpleClient.Close();
        }
    }
}
