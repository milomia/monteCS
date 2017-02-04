using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace MonteCarloConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(MonteRemoteTest.MonteCarloService.MonteCarloServiceClient)))
            {

                double num_sims = 10000; // Number of simulated asset paths
                double S = 100.0; // Option price
                double K = 100.0; // Strike price
                double r = 0.05;  // Risk free rate (5%)
                double v = 0.2;   // volatility of the underlying (20%)
                double T = 1.0;   // One year until expiry

                //     MonteRemoteTest.MonteCarloService.MonteCarloServiceClient mc = new MonteRemoteTest.MonteCarloService.MonteCarloServiceClient();

                host.Open();

                double call = -1.0;
                double put = 1.0;

                //double call = mc.GetCallPrice(ref num_sims, ref S, ref K, ref r, ref v, ref T);
                //double put = mc.GetPutPrice(ref num_sims, ref S, ref K, ref r, ref v, ref T);

                // Finally we output the parameters and prices
                System.Console.WriteLine("Number of paths: {0}", num_sims);

                System.Console.WriteLine("Underlying: {0}", S);
                System.Console.WriteLine("Strike: {0}", K);
                System.Console.WriteLine("Risk-Free Rate: {0}", r);
                System.Console.WriteLine("Volatility: {0}", v);
                System.Console.WriteLine("Maturity: {0}", T);

                System.Console.WriteLine("Call Price: {0}", call);
                System.Console.WriteLine("Call Price: {0}", put);

                Console.WriteLine("Host Started = {0}", DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
