using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyProject
{
    public class System
    {
        public static Random rand = new Random();
        public static List<User> user;
        public static int FactCountUser { get; set; }
        public static List<User> GetUser()
        {
            user = new List<User>();
            FactCountUser = rand.Next(20, 50);
            for (int i = 0; i < FactCountUser; i++)
            {
                user.Add(new User(i+1));
            }
            return user;
        }
        public static void Production(List<User> user, ProxyServ proxy)
        {
            Authentification.AddUser(50);
            foreach (User users in user)
            {
                
                Packet request =users.GetRequest(users);//формируем запросы 
                try
                {
                    Authentification.UserCheck(users);
                    proxy.Prepare(request);
                    Packet response = users.GetResponse(proxy, request, users);//ответ
                    Console.WriteLine("Запрос клиента {0} к объекту - {1}. Ответ получен!", users.IP + 1, request.Destination);
                }
                catch (ExceptionWhenAuth e)
                {
                    Console.WriteLine("Клиента {0} - нет в базе!", request.Sourse);
                }
                catch (ExceptionWhenCorrecherss e)
                {
                    Console.WriteLine("Запрос клиента {0} к объекту - {1}. Запрос не коректен!", request.Sourse, request.Destination);
                }
                catch (ExceptionWhenAccess e)
                {
                    Console.WriteLine("Запрос клиента {0} кобъекту - {1}. Ресурс временно недоступен!", request.Sourse, request.Destination);
                }
                catch (ExceptionWhenAnswer e)
                {
                    Console.WriteLine("Запрос клиента {0} кобъекту - {1}. Нет прав досупа!", request.Sourse, request.Destination);
                }
            }
        }
    }
}