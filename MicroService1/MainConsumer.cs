using MassTransit;
using Shared;
using System;
using System.Threading.Tasks;

namespace MicroService1
{
    public class MainConsumer : IConsumer<RequestService>
    {
        public Task Consume(ConsumeContext<RequestService> context)
        {
            // do something here, consume the message and execute its command.

            context.Publish<RequestServiceProcessed>(new Msg()
            {
                Time = DateTime.Now,
                Message = typeof(MainConsumer).FullName
            });
            
            return context.ConsumeCompleted;            
        }

        private class Msg : RequestServiceProcessed
        {
            public string Message {get; set; }
            public DateTime Time { get; set; }
        }
    }
}
