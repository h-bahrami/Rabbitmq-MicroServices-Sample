using MassTransit;
using Shared;
using System;
using System.Threading.Tasks;

namespace MicroService2
{
    public class MainConsumerSrv2 : IConsumer<Service2Command>
    {
        public Task Consume(ConsumeContext<Service2Command> context)
        {
            context.Respond<RequestServiceProcessed>(
                new RequestServiceProcessedImpl()
                {
                    Time = DateTime.Now,
                    Message = $"Hi from MicroService2.MicroService2",
                    Sent = null,
                    Received = context.Message
                });


            return Task.CompletedTask;
        }
    }

    class RequestServiceProcessedImpl : RequestServiceProcessed
    {
        public DateTime Time { get; set; }

        public string Message { get; set; }

        public object Sent { get; set; }

        public object Received { get; set; }
    }
}
