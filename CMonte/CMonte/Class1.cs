using ExcelDna.Integration;
using System;

// commit to pick upstairs
public static class MyFunctions
{
    [ExcelFunction(Description = "Monte Carlo Pricer")]
    public static string MC_Call(
    [ExcelArgument(Name = "numSims", Description = "number of simulations")]
    double num_sims,
    [ExcelArgument(Name = "optionPrice", Description = "the Option price")]
    double S,
    [ExcelArgument(Name = "strikePrice", Description = "the Strike price")]
    double K,
    [ExcelArgument(Name = "riskFreeRate", Description = "the Risk Free Interest Rate")]
    double r,
    [ExcelArgument(Name = "volatility", Description = "the volatility of the underlying")]
    double v,
    [ExcelArgument(Name = "time to expiry", Description = "time to expiry")]
    double T)
    {
         Monte mc = new Monte();

         double call = mc.GetCallPrice(ref num_sims, ref S, ref K, ref r, ref v, ref T);

         return call.ToString();
    }
    public static string MC_Put(
    [ExcelArgument(Name = "numSims", Description = "number of simulations")]
    double num_sims,
    [ExcelArgument(Name = "optionPrice", Description = "the Option price")]
    double S,
    [ExcelArgument(Name = "strikePrice", Description = "the Strike price")]
    double K,
    [ExcelArgument(Name = "riskFreeRate", Description = "the Risk Free Interest Rate")]
    double r,
    [ExcelArgument(Name = "volatility", Description = "the volatility of the underlying")]
    double v,
    [ExcelArgument(Name = "time to expiry", Description = "time to expiry")]
    double T)
    {

        Monte mc = new Monte();

        double put = mc.GetPutPrice(ref num_sims, ref S, ref K, ref r, ref v, ref T);

        return put.ToString();
    }
}
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



}