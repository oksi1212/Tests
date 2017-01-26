using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyProject
{
    public class ProxyServ : Subject
    {
    	RealSubject resourse;
        public ProxyServ(RealSubject resourse)
        {
            this.resourse = resourse;
        }
        public void Prepare(Packet packet)
    	{
    		Rules correct = new Correcherss();
    		Rules access = new Access();
    		Rules answer = new Answer();
    		correct.NextRules = access;
    		access.NextRules = answer;
            correct.Rule(packet);
    	}
        public override Packet Response(Packet request , User user)
        {
            Packet response = new  Packet();
              bool i = Answer.AnswerUser(request);
            if (!i)
            {
                response = resourse.Response(request, user);
                Answer.AddUsedData(request, response);
            }
            else
            {
                response = request;
                response.Sourse = request.Destination;
                response.Destination = request.Sourse;   
            }
            
            return response;
        }
    }
}
