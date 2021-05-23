using System;
using System.Collections.Generic;
using System.Text;

namespace CovidApp.Model
{
    public class ServerResponse<T>
    {
        public string Message { get; set; }
        public T Payload { get; set; }
    }
}
