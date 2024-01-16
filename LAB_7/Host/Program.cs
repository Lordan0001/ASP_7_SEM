using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(Lab7.Feed1));
            host.Open();
            Console.WriteLine("Host is opened");
            string s = Console.ReadLine();
        }
    }
}
