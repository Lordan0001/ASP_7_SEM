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
            string binding = "tcpEndpoint";
            WCFReference.WCFSimplexClient simpleClient = new WCFReference.WCFSimplexClient(binding);
            Console.WriteLine("ADD: " + simpleClient.Add(111, 2222));
            Console.WriteLine("CONCAT: " + simpleClient.Concat("Vlad", 3));
            WCFReference.A a = simpleClient.Sum(new WCFReference.A { f = 12.2f, k = 33, s = "new " }, new WCFReference.A { f = 22.3f, k = 3, s = "str" });
            Console.WriteLine($"SUM: f = {a.f} k = {a.k} s = {a.s}");
            Console.ReadLine();
            simpleClient.Close();
        }
    }
}
