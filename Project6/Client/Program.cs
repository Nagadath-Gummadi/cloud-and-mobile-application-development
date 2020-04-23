using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace Client
{

    [ServiceContract]
    public interface IProblemSolver
    {
        [OperationContract]
        int add(int a, int b);
    }
    public interface IProblemSolverChannel : IProblemSolver, IClientChannel { }
    class Program
    {
        static void Main(string[] args)
        {
            var ch = new ChannelFactory<IProblemSolverChannel>("solvercep");
            var channel = ch.CreateChannel();
            Console.Write("sum:" + channel.add(10, 20));


        }
    }
}
