using System;
using System.ServiceModel;
namespace Service
{
    [ServiceContract]
    public interface IProblemSolver
    {
        [OperationContract]
        int add(int a, int b);
    }
    class ProblemSolver : IProblemSolver
    {
        public int add(int a, int b)
        {
            return a + b;
            throw new NotImplementedException();
        }

    }
    class Program
    {
        static void Main()
        {
            
            ServiceHost host = new ServiceHost(serviceType: typeof(ProblemSolver));
            host.Open();
            
            Console.Write("started");
            host.Close();
           
        }

    }
}





