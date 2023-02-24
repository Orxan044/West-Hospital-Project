using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyExceptuinN
{
    internal class MyException : ApplicationException
    {
        private string _mes;
        public DateTime TimeException { get; private set; }
        public MyException()
        {
            _mes = "";
            TimeException = DateTime.Now;
        }
        public MyException(string mes)
        {
            _mes = mes;
        }

        public override string Message
        {

            get { return _mes; }
        }


    }
}
