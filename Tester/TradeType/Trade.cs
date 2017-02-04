using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trade
{
    public class Trade
    {
        Trade CreateTrade(string type)
        {
            switch(type)
            {
                case "bond":
                    return new Bond();
                case "equity":
                    return new Equity();
                case "option":
                    return new Option();
                default:
                    return null;
            }
        }
    }


    public class Bond:Trade
    {
        string _name = "bond";
        decimal _bondCoupon = 3.14M;

        public decimal getBondCoupon()
        {
            return _bondCoupon;
        }
        public string getBondName()
        {
            return _name;
        }
    }

    public class Equity : Trade
    {
        decimal _stockPrice = 9.81M;

        public decimal getStockPrice()
        {
            return _stockPrice;
        }
    }

    public class Option:Trade
    {
        decimal _strikePrice = 2.71M;

        public decimal getStrikePrice()
        {
            return _strikePrice;
        }
    }
}
