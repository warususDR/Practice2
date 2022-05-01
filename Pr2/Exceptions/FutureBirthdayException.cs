using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeDateHandling.Exceptions
{
    class FutureBirthdayException : Exception
    {
        public FutureBirthdayException() : base("Given birthday is in the future! Please enter correct date of birth!")
        { }
    }
}
