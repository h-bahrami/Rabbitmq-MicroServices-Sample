using System;

namespace Shared
{
    public interface ISimpleResponse
    {
        public DateTime Time { get; }
        public string Message { get; }

        public object Received { get;}
        public object Sent { get;}
    }
}
