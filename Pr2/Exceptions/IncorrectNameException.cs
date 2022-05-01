using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDateHandling.Exceptions
{
    class IncorrectNameException: Exception
    {
        public IncorrectNameException() : base("String that represents your name or surname should contain only letters!")
        {

        }
    }
}
