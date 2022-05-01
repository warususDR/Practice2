using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDateHandling.Exceptions
{
    class PastBirthdayException: Exception
    {
        public PastBirthdayException() : base("You can't be so old... Please enter a correct date of birth!")
        { }
    }
}
