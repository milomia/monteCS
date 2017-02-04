using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeFactory
{
    public class TradeFactory
    {
        private TradeFactory() { }

        public static Trade.Trade CreateTrade(string trade)
        {
            Trade.Trade _tradeType;

            switch (trade)
            {
                case "Bond":
                    _tradeType = CreateBond();
                    break;
                case "Equity":
                    _tradeType = CreateEquity();
                    break;
                case "Option":
                    _tradeType = CreateOption();
                    break;
                default:
                    _tradeType = null;
                    break;
            }

            Type tradeType = Type.GetType(trade);

            return _tradeType;
        }

        public static Trade.Trade CreateBond()
        {
            var bond = new Trade.Bond();
            return bond;
        }

        public static Trade.Trade CreateEquity()
        {
            var bond = new Trade.Bond();
            return bond;
        }

        public static Trade.Trade CreateOption()
        {
            var bond = new Trade.Bond();
            return bond;
        }
    }
}
