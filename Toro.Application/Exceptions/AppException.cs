using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Toro.Application.Exceptions
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

    }
}
