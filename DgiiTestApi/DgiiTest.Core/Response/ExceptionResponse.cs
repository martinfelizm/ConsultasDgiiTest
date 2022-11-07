using System;
using System.Collections.Generic;
using System.Text;

namespace DgiiTest.Core.Response
{
    public class ExceptionResponse : Exception
    {
        public ExceptionResponse(string message):base(message)
        {
            
        }
        
    }
}
