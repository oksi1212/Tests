using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ProxyProject
{
    public class Authentification
    {
        public static string GetPassword(int password)
        {
            string pass = "";
            HashAlgorithm sha1 = new SHA1CryptoServiceProvider();
            byte[] passwordByte = BitConverter.GetBytes(password);
            byte[] passwordHash = sha1.ComputeHash(passwordByte);
            pass = Encoding.Unicode.GetString(passwordHash);
            return pass;
        }
        public static string[] ReadingPassword()
        {
            return File.ReadAllLines("password.txt");
        }
        public static void AddUser(int Count)
        {
            StreamWriter file = new StreamWriter("password.txt");
            for(int i = 0; i<Count; i++)
            {
                string password = "";
                password = GetPassword(i);
                file.WriteLine(password);
            }
            file.Close();
        }
        public static bool UserCheck(User user)
        {
        	bool flag = false;
        	string[] password = ReadingPassword();
            string passwordUser = GetPassword(user.IP);
        	for(int i = 0; (i<password.Length) &&(!flag); i++ )
        	{
        		if(passwordUser == password[i])
        		{
        			flag = true;
        		}
        	}
        	return flag;
        }

        public static void ClientAuthentification(User user)
        {
           if(!UserCheck(user))
           {
              throw new ExceptionWhenAuth();
           }
        }
    }
}
