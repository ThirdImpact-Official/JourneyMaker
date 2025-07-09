using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoundBoard.Service.Exceptions
{
    /*
    * Exception thrown when a business rule is violated
    */
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) {

        }

        public BusinessException(string message, Exception innerException) : base(message, innerException) {}
    }
}