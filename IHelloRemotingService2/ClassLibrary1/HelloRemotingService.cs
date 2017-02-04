using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloRemotingService
{
    public class HelloRemotingService : MarshalByRefObject, IHelloRemotingService2.IHelloRemotingService
    {
        public string GetMessage(string name)
        {
            return "Hello" + name;
        }
    }
}
