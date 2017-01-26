using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyProject
{
    public abstract class Subject
    {
       public abstract Packet Response(Packet request, User user);
    }
}
