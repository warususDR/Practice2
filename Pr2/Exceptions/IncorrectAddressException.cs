using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDateHandling.Exceptions
{
    class IncorrectAddressException: Exception
    {
        public IncorrectAddressException() : base("Incorrect email format. Please enter correct address!")
        { }
    }
}
