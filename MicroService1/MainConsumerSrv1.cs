using MassTransit;
using Shared;
using System;
using System.Threading.Tasks;

namespace MicroService1
{
    public class MainConsumerSrv1 : IConsumer<IService1Request>
    {
        private readonly IBus bus;

        public MainConsumerSrv1(IBus bus)
        {
            this.bus = bus;
        }
        public async Task Consume(ConsumeContext<IService1Request> context)
        {
            // do something here, consume the message and execute its command.
            // var sendEndpoint = await context.GetSendEndpoint(new Uri(""));
            // sendEndpoint.send

            var message = await context.Request<IService2Request, ISimpleResponse>(this.bus, 
                new Service2CommandImpl(){ Id = 1230, Name = "Hossein Bahrami" });            
            
            await context.RespondAsync<ISimpleResponse>(new Msg()
            {
                Time = DateTime.Now,
                Message = typeof(MainConsumerSrv1).FullName,
                Sent = message.Message,
                Received = context.Message
            });           
        }

        private class Service2CommandImpl : IService2Request
        {
            public int Id {get; set; }

            public string Name { get; set; }
        }

        private class Msg : ISimpleResponse
        {
            public string Message {get; set; }
            public DateTime Time { get; set; }

            public object Sent { get; set; }

            public object Received {get; set; }
        }
    }
}
