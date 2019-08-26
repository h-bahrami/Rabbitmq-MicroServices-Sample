using System;

namespace Shared
{
    public interface RequestService
    {
        public DateTime Time { get; }
        public string Message { get; }
    }
}
