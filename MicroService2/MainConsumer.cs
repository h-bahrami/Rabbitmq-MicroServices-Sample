using MassTransit;
using Shared;
using System.Threading.Tasks;

namespace MicroService2
{
    public class MainConsumer : IConsumer<RequestService>
    {
        public Task Consume(ConsumeContext<RequestService> context)
        {
            return Task.CompletedTask;
        }
    }
}
