using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace ProxyProject
{
    public  class Correcherss : Rules
    {
       public override void Rule(Packet packet)
       {
       	if(!(packet.Head != null) && (packet.Body != null))
       	{
       		throw new ExceptionWhenCorrecherss();
       	}
            else if (NextRules != null)
                NextRules.Rule(packet);
        }
    }
}
