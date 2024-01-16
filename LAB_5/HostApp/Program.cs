using System;
using System.ServiceModel;
using WCF;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost sh = null;
            sh = new ServiceHost(typeof(WCFSimplex));
            sh.Open();
            Console.WriteLine("Service running in http://localhost:8739");
            Console.ReadLine();
        }
    }
}
