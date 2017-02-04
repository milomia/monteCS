using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IHelloRemotingService2
{
    public interface IHelloRemotingService
    {
        string GetMessage(string name);
    }
}
