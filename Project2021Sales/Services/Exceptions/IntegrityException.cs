using System;

namespace Project2021Sales.Services.Exceptions
{
    public class IntegrityException :ApplicationException
    {
        public IntegrityException(string message) : base(message)
        {

        }
    }
}
