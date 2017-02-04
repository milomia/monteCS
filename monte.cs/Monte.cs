using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Monte
    { 
    
        public double gaussian_box_muller()
        {
        double x = 0.0;
        double y = 0.0;
        double euclid_sq = 0.0;
        double val = 0.0;

        // Continue generating two uniform random variables
        // until the square of their "euclidean distance"
        // is less than unity

        Random r = new Random();
        do
        {
            x = 2.0 * r.Next(10000) / 10000 - 1;
            y = 2.0 * r.Next(10000) / 10000 - 1;
            euclid_sq = x * x + y * y;
        } while (euclid_sq >= 1.0);

        val = Math.Log(euclid_sq) / euclid_sq;
        val = -2 * Math.Log(euclid_sq) / euclid_sq;

        return x * Math.Sqrt(-2 * Math.Log(euclid_sq) / euclid_sq);
    }
    

    // Pricing a European vanilla call option with a Monte Carlo method
    public double GetCallPrice(ref double num_sims, ref double S, ref double K, ref double r, ref double v, ref double T)
    {
        double S_adjust = S * Math.Exp(T * (r - 0.5 * v * v));
        double S_cur = 0.0;
        double payoff_sum = 0.0;

        for (int i = 0; i < num_sims; i++)
        {
            double gauss_bm = gaussian_box_muller();
            S_cur = S_adjust * Math.Exp(Math.Sqrt(v * v * T) * gauss_bm);
            payoff_sum += Math.Max(S_cur - K, 0.0);
        }

        return (payoff_sum / num_sims) * Math.Exp(-r * T);

    }


    // Pricing a European vanilla puy option with a Monte Carlo method
    public double GetPutPrice(ref double num_sims, ref double S, ref double K, ref double r, ref double v, ref double T)
    {
        double S_adjust = S * Math.Exp(T * (r - 0.5 * v * v));
        double S_cur = 0.0;
        double payoff_sum = 0.0;

        for (int i = 0; i < num_sims; i++)
        {
            double gauss_bm = gaussian_box_muller();
            S_cur = S_adjust * Math.Exp(Math.Sqrt(v * v * T) * gauss_bm);
            payoff_sum += Math.Max(K - S_cur, 0.0);
        }

        return (payoff_sum / num_sims) * Math.Exp(-r * T);
    }



    class Program
    {
        static void Main(string[] args)
        {
       
                double num_sims = 1000000; // Number of simulated asset paths
                double S = 100.0; // Option price
                double K = 100.0; // Strike price
                double r = 0.05;  // Risk free rate (5%)
                double v = 0.2;   // volatility of the underlying (20%)
                double T = 1.0;   // One year until expiry

                Monte mc = new Monte();
                
                double call = mc.GetCallPrice(ref num_sims, ref S, ref K, ref r, ref v, ref T);
                double put = mc.GetPutPrice(ref num_sims, ref S, ref K, ref r, ref v, ref T);

                // Finally we output the parameters and prices
                System.Console.WriteLine("Number of paths: {0}", num_sims);

                System.Console.WriteLine("Underlying: {0}", S);
                System.Console.WriteLine("Strike: {0}", K);
                System.Console.WriteLine("Risk-Free Rate: {0}", r);
                System.Console.WriteLine("Volatility: {0}", v);
                System.Console.WriteLine("Maturity: {0}", T);

                System.Console.WriteLine("Call Price: {0}", call);
                System.Console.WriteLine("Put Price: {0}", put);

                Console.WriteLine("Host Started = {0}", DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }


