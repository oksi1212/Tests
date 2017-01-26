using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<User> user = System.GetUser();
            ProxyServ proxy = new ProxyServ(new ProxyProject.RealSubject());
            System.Production(user, proxy);
            Console.ReadKey();

        }
    }
}
