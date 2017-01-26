using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyProject
{
    public class RealSubject : Subject
    {
      public Packet GetResponse(User user)
      {
           Packet packet = new Packet();
           int time = 24; 
           Random random = new Random();
           packet = Packet.GetPacket();
           packet.Destination = user.IP;
           packet.Time = random.Next(time);
           return packet;
      }
      public override Packet Response(Packet response , User user)
      {       
        return GetResponse(user);
      }
    }
}
