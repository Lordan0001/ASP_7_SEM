using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class WCFSimplex : IWCFSimplex
    {
        public int Add(int x, int y) => x + y;

        public string Concat(string s, double d) => s + d;

        public A Sum(A a1, A a2) => new A(a1.s + a2.s, a1.k + a2.k, a1.f + a2.f);
    }
}
