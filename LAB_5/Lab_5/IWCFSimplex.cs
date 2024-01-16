using System.ServiceModel;

namespace WCF
{
    [ServiceContract]
    public interface IWCFSimplex
    {
        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        string Concat(string s, double d);

        [OperationContract]
        A Sum(A a1, A a2);
    }
}
