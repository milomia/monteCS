using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace monteConsole
{
    public class monte
    {
        // a simple implementation of the Box-Muller algorithm, used to generate
        // gaussian random numbers - necessary for the Monte Carlo method below
        // Note that C++11 actually provides std::normal_distribution<> in
        // the <random> library, which can be used instead of this function
        double gaussian_box_muller()
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
        double monte_carlo_call_price(ref int num_sims, ref double S, ref double K, ref double r, ref double v, ref double T)
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
        double monte_carlo_put_price(ref int num_sims, ref double S, ref double K, ref double r, ref double v, ref double T)
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
        static void Main(string[] args)
        {
            int num_sims = 10000; // Number of simulated asset paths
            double S = 100.0; // Option price
            double K = 100.0; // Strike price
            double r = 0.05;  // Risk free rate (5%)
            double v = 0.2;   // volatility of the underlying (20%)
            double T = 1.0;   // One year until expiry

            monte m = new monte();

            // then we calculate the call/put values via monte carlo
            double call = m.monte_carlo_call_price(ref num_sims, ref S, ref K, ref r, ref v, ref T);
            double put = m.monte_carlo_put_price(ref num_sims, ref S, ref K, ref r, ref v, ref T);

            // Finally we output the parameters and prices
            System.Console.WriteLine("Number of paths: {0}", num_sims);

            System.Console.WriteLine("Underlying: {0}", S);
            System.Console.WriteLine("Strike: {0}", K);
            System.Console.WriteLine("Risk-Free Rate: {0}", r);
            System.Console.WriteLine("Volatility: {0}", v);
            System.Console.WriteLine("Maturity: {0}", T);

            System.Console.WriteLine("Call Price: {0}", call);
            System.Console.WriteLine("Call Price: {0}", put);
        }
    }
}
