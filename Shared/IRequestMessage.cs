using System;

namespace Shared
{
    public interface IRequestMessage
    {
        public DateTime RecordTime { get; }
        public string Message { get; }
    }
}
