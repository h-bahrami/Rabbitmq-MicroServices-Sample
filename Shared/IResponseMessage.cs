using System;

namespace Shared
{
    public interface IResponseMessage
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}
