using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyProject
{
    public class Packet
    {
        public byte[] Body { get; set; }
        private static int bodyLength;
        private static int BodyLength
        {
            get{ 
                return bodyLength = 26000;
             }
           
        }

        public byte[] Head { get; set; }
        private static int headLength;
        private static int HeadLength
        {
            get{
             return headLength = 32; 
            }
        }
           
        public int Sourse { get; set; }//откуда
        public int Destination { get; set; } //куда
        public int Time { get; set; }

        public static Packet GetPacket()
        {
            Random random = new Random();
            Packet packet = new Packet();
            packet.Head = new byte[HeadLength];
            random.NextBytes(packet.Head);
            packet.Body = new byte[random.Next(BodyLength)];
            random.NextBytes(packet.Body);
            return packet;
        }
    }
}
