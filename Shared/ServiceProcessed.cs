using System;

namespace Shared
{
    public interface RequestServiceProcessed
    {
        public DateTime Time { get; set; }
        public string Message { get; set; }
    }
}
