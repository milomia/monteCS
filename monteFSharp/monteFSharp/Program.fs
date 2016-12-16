
        module monteF

  //type monte = class
  //      val x:int
    
        // a simple implementation of the Box-Muller algorithm, used to generate
        // gaussian random numbers - necessary for the Monte Carlo method below
        // Note that C++11 actually provides std::normal_distribution<> in
        // the <random> library, which can be used instead of this function

        let max num1 num2 : float = 
            // function body
            if(num1>num2)then
                num1
            else
                num2
            
        let gaussian_box_muller() : float =
        
            let mutable x:float = 0.0
            let mutable y:float = 0.0
            let mutable euclid_sq:float = 2.0
            let mutable value:float = 0.0

            // Continue generating two uniform random variables
            // until the square of their "euclidean distance"
            // is less than unity
            // test

            let r = new System.Random()
        
            while (euclid_sq  > 1.0) do
                x <- (2.0 * r.NextDouble() - 1.0)
                y <- 2.0 * r.NextDouble() - 1.0
                euclid_sq <- x * x + y * y
                0
          
            let value = -2.0 * log(euclid_sq) / euclid_sq
            let ran = x * sqrt(value)
            ran
        

        // Pricing a European vanilla call option with a Monte Carlo method
        let monte_carlo_call_price(num_sims, S, K, r, v, T) : float =
        
            let mutable S_adjust = S * exp(T * (r - 0.5 * v * v))
            let mutable S_cur = 0.0
        
            let mutable payoff_sum = 0.0

            for i = 0 to num_sims do
                let gauss_bm = gaussian_box_muller()
                let temp = exp(sqrt(v * v * T) * gauss_bm)
                S_cur <- S_adjust * temp
                payoff_sum <- max (S_cur - K)  0.0 + payoff_sum
                0
            
            (payoff_sum / (float)num_sims) * exp(-r * T)

        // Pricing a European vanilla puy option with a Monte Carlo method
        let monte_carlo_put_price(num_sims, S, K, r, v, T) : float =
        
            let mutable S_adjust = S * exp(T * (r - 0.5 * v * v))
            let mutable S_cur = 0.0
            let mutable payoff_sum = 0.0

            for i = 0 to num_sims do
                let gauss_bm = gaussian_box_muller();
                let temp = exp(sqrt(v * v * T) * gauss_bm)
                S_cur <- S_adjust * temp
                payoff_sum <- max (K - S_cur) 0.0 + payoff_sum
                0
           
            (payoff_sum / (float)num_sims) * exp(-r * T);

        [<EntryPoint>]
        let main argv = 
           
            let num_sims = 10000; // Number of simulated asset paths
            let S = 100.0; // Option price
            let K:float = 100.0; // Strike price
            let r = 0.05;  // Risk free rate (5%)
            let v = 0.2;   // volatility of the underlying (20%)
            let T = 1.0;   // One year until expiry

            // let m = monte();

            // then we calculate the call/put values via monte carlo
            let call = monte_carlo_call_price(num_sims, S, K, r, v, T)
            let put  = monte_carlo_put_price(num_sims,  S, K, r, v, T)

            // Finally we output the parameters and prices
            printfn "Number of paths: %f", num_sims

            printfn "Underlying: %f", S
            printfn "Strike: %f", K
            printfn "Risk-Free Rate: %f", r
            printfn "Volatility: %f", v
            printfn "Maturity: %f", T

            printfn "Call Price: %f", call
            printfn "Call Price: %f", put
            System.Console.ReadLine()
            0
       