using MassTransit;
using Shared;
using System;
using System.Threading.Tasks;

namespace MicroService2
{
    public class MainConsumerSrv2 : IConsumer<IService2Request>
    {
        public Task Consume(ConsumeContext<IService2Request> context)
        {
            context.Respond<ISimpleResponse>(
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

    class RequestServiceProcessedImpl : ISimpleResponse
    {
        public DateTime Time { get; set; }

        public string Message { get; set; }

        public object Sent { get; set; }

        public object Received { get; set; }
    }
}
