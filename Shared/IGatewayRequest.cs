using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IGatewayRequest 
    {
        public string Message { get; }
    }
}
