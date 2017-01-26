using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProxyProject
{
    public class Answer : Rules
    {
        public static  bool AnswerUser(Packet packet)
        {
            bool flag = true;
            string[] answer = File.ReadAllLines("AnswerUser.txt");
            string[] s = new string[] { " ", "-" };
            for (int i = 0; i < answer.Length; i++)
            {
                string[] value = answer[i].Split(s, StringSplitOptions.RemoveEmptyEntries);             
                if ((packet.Sourse == Convert.ToInt32(value[0])) &&(packet.Destination == Convert.ToInt32(value[1])))
                {
                    flag = (Convert.ToInt32(value[2]) == 1);
                }
            }
            return flag;
        }
        public static void AddUsedData(Packet request, Packet response)//добавить
        {
            StreamWriter file = new StreamWriter("AnswerUser.txt");
            string sours = "";
            sours = Convert.ToString(request.Sourse)+"-" +Convert.ToString(response.Sourse) +" 1";
            file.WriteLine(sours);
            file.Close();
        }
        public override void Rule(Packet packet)
        {
       	if(!AnswerUser(packet))
       	{
       		throw new ExceptionWhenAnswer();
       	}
            else if (NextRules != null)
            NextRules.Rule(packet);
        }
    }
}
