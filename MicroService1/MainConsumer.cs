using MassTransit;
using Shared;
using System;
using System.Threading.Tasks;

namespace MicroService1
{
    public class MainConsumer : IConsumer<IRequestMessage>
    {
        public Task Consume(ConsumeContext<IRequestMessage> context)
        {
            context.Respond<IRequestMessage>(new Msg()
            {
                RecordTime = DateTime.Now,
                Message = typeof(MainConsumer).FullName
            });
            return Task.CompletedTask;
        }

        private class Msg : IRequestMessage
        {
            public DateTime RecordTime { get; set; }
            public string Message {get; set; }
        }
    }
}
