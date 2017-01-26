using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyProject
{
	public class ExceptionWhenAuth : Exception
	{
        public ExceptionWhenAuth() { }
	}
    public class ExceptionWhenCorrecherss : Exception
	{
         public ExceptionWhenCorrecherss() { }
	}
    public class ExceptionWhenAccess : Exception
    {
        public ExceptionWhenAccess() { }
    }
    public class ExceptionWhenAnswer : Exception
    {
        public ExceptionWhenAnswer() { }
    }
}