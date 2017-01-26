using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyProject
{
    public  class User : Packet
    {
       private int ip;
       public int IP
       {
            get
            {
                return this.ip = ip;
            }
            set{
                if(value > 0)
                    this.ip = value; 
                }
        } 
       	public User (int ip)
       	{
       	     IP=ip;
       	}
         public Packet GetRequest(User user)
        {
            int time = 24;
            int subject =100;
            Random rand = new Random();
            Packet request = GetPacket();
            request.Sourse = user.IP;
            request.Destination = rand.Next(subject); 
            request.Time = rand.Next(time);
            return request;
        }
         public Packet GetResponse(Subject proxy, Packet packet, User user)
          {
             return proxy.Response(packet, user);            
          }
    }
}

