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
                
                Packet request =users.GetRequest(users);//��������� ������� 
                try
                {
                    Authentification.UserCheck(users);
                    proxy.Prepare(request);
                    Packet response = users.GetResponse(proxy, request, users);//�����
                    Console.WriteLine("������ ������� {0} � ������� - {1}. ����� �������!", users.IP + 1, request.Destination);
                }
                catch (ExceptionWhenAuth e)
                {
                    Console.WriteLine("������� {0} - ��� � ����!", request.Sourse);
                }
                catch (ExceptionWhenCorrecherss e)
                {
                    Console.WriteLine("������ ������� {0} � ������� - {1}. ������ �� ��������!", request.Sourse, request.Destination);
                }
                catch (ExceptionWhenAccess e)
                {
                    Console.WriteLine("������ ������� {0} �������� - {1}. ������ �������� ����������!", request.Sourse, request.Destination);
                }
                catch (ExceptionWhenAnswer e)
                {
                    Console.WriteLine("������ ������� {0} �������� - {1}. ��� ���� ������!", request.Sourse, request.Destination);
                }
            }
        }
    }
}