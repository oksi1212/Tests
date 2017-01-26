using System;
using System.Text;
using System.IO;

namespace ProxyProject
{
    public class Access : Rules
    {
      private bool AccessSubject(Packet packet)
      {
        bool flag = true;
        string[] access = File.ReadAllLines("AccessSubject.txt");
        string[] s = new string[] { " ", "-" };
        for ( int i=0; (i<access.Length) && flag; i++)
        {
           string[] value = access[i].Split(s, StringSplitOptions.RemoveEmptyEntries);
           if(packet.Destination == Convert.ToInt32(value[0]))
                    flag = (packet.Time > Convert.ToInt32(value[1])) && (packet.Time < Convert.ToInt32(value[2]));
            }
         return flag;
       }
       public override void Rule(Packet packet)
       {
            if (!AccessSubject(packet))
            {
                throw new ExceptionWhenAccess();
            }
            else if (NextRules != null)
            {

                NextRules.Rule(packet);
            }
       }
    }
}
